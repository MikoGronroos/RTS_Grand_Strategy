using UnityEngine;

public class MergeSprites
{

    public static Sprite Merge(SpriteRenderer[] spriteRenderersToMerge)
    {

        Resources.UnloadUnusedAssets();

        Sprite[] spritesToMerge = new Sprite[spriteRenderersToMerge.Length];

        for (int i = 0; i < spriteRenderersToMerge.Length; i++)
        {
            spritesToMerge[i] = spriteRenderersToMerge[i].sprite;
        }

        int width = 0;
        int height = 0;

        foreach (var tex in spritesToMerge)
        {
            width += tex.texture.width;
            height += tex.texture.height;
        }

        var newTex = new Texture2D(width, height);

        for (int x = 0; x < newTex.width; x++)
        {
            for (int y = 0; y < newTex.height; y++)
            {
                newTex.SetPixel(x, y, new Color(1, 1, 1, 0));
            }
        }

        for (int i = 0; i < spritesToMerge.Length; i++)
        {
            for (int x = 0; x < spritesToMerge[i].texture.width; x++)
            {
                for (int y = 0; y < spritesToMerge[i].texture.width; y++)
                {
                    var color = spritesToMerge[i].texture.GetPixel(x,y).a == 0 ? newTex.GetPixel(x,y) : spritesToMerge[i].texture.GetPixel(x,y);
                    newTex.SetPixel(x, y, color);
                }
            }
        }

        newTex.Apply();
        var finalSprite = Sprite.Create(newTex, new Rect(0, 0, newTex.width, newTex.height), new Vector2(0.5f, 0.5f));
        finalSprite.name = "New Sprite";
        return finalSprite;

    }

}
