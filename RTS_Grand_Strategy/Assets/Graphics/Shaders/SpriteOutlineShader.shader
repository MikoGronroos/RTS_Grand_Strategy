Shader "Custom/SpriteOutlineShader"
{
    Properties
    {
        [NoScaleOffset] [HideInInspector] _MainTex ("Texture", 2D) = "white" {}
        [KeywordEnum(Ultra, High, Normal, Low)] _OutlineQuality("Outline Quality", Float) = 0
        [Toggle] _FillBackground ("FillBackground", float ) = 0
        _OutlineColor ("OutlineColor", Color ) = (1,1,1,1)
        _OutlineWidth ("OutlineWidth", range(0,10)) = 2
        _OutlineSharpness ("OutlineSharpness", range(0.01,1)) = 0.15
    }
    SubShader
    {
        Tags {		
            "Queue"="Transparent" 
			"IgnoreProjector"="True" 
			"RenderType"="Transparent" 
			"PreviewType"="Plane"
			"CanUseSpriteAtlas"="True"
        }

		Cull Off
		Lighting Off
		ZWrite Off
        
        Blend SrcAlpha OneMinusSrcAlpha

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"

            struct MeshData
            {
                float4 vertex : POSITION;
                fixed4 color : COLOR;
                float2 uv : TEXCOORD0;
            };

            struct Interpolators
            {
                float4 vertex : SV_POSITION;
                fixed4 color : COLOR;
                float2 uv : TEXCOORD0;
            };

            sampler2D _MainTex;
            float4 _MainTex_ST;
            int _OutlineQuality;
            float _FillBackground;
            float4 _OutlineColor;
            float _OutlineWidth;
            float _OutlineSharpness;

            Interpolators vert (MeshData v)
            {
                Interpolators o;

                // v.vertex *= 1.5;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                o.color = v.color;
                return o;
            }

            float GetCombinedAlpha(float2 uv)
            {
                float result = 0;
                int quality;
                
                switch (_OutlineQuality)
                {
                    case 0:
                        quality = 360;
                        break;
                    case 1:
                        quality = 180;
                        break;
                    case 2:
                        quality = 90;
                        break;
                    case 3:
                        quality = 45;
                        break;
                    default:
                        quality = 45;
                        break;
                }
                
                for (int i = 0; i < quality; i++)
                {
                    float width = _OutlineWidth * 0.01;
                    float2 sUV = uv + float2(cos(i), sin(i)) * width;
                    result = max(result, tex2D(_MainTex,sUV).a);
                }
                return result;
            }
            
            fixed4 frag (Interpolators i) : SV_Target
            {
                fixed4 main = tex2D(_MainTex, i.uv);
                
                
                half combinedMask = GetCombinedAlpha(i.uv);

                half dist = length(float2(combinedMask, combinedMask))-0.5;
                half pwidth = length(float2(ddx(dist), ddy(dist)));
                half coverage = saturate( dist/pwidth * _OutlineSharpness + 0.5 );
                half alpha = coverage * coverage * (3 - 2 * coverage);

                fixed3 rgb;
                half a;
                
                half smoothMain = smoothstep(0.5,1, main.a);
                half outlineMask = alpha - smoothMain;
                half reverseOutline = 1-outlineMask;

                main *= i.color;
                
                if(!_FillBackground)
                {
                    rgb = lerp(_OutlineColor.rgb, main.rgb, reverseOutline);
                    a = lerp(outlineMask, main.a, reverseOutline * i.color.a * alpha);
                }
                else
                {
                    rgb = lerp(_OutlineColor.rgb, main.rgb*i.color.a, reverseOutline * i.color.a);
                    a = alpha;
                }
                
                return fixed4(rgb, a);
            }
            ENDCG
        }

    }
}
