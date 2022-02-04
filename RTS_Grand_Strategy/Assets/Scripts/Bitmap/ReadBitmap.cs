using UnityEngine;
using System.IO;
using System.Collections.Generic;

public class ReadBitmap : MonoBehaviour
{

    [SerializeField] private Sprite image;
    [SerializeField] private GameObject provinceObject;

    [SerializeField] private List<Sprite> sprites = new List<Sprite>();

    [SerializeField] private GameObject spritesParent;

    [SerializeField] private GameEvent onProvincesCreatedEvent;

    private Dictionary<Color32, GameObject> spriteObjects = new Dictionary<Color32, GameObject>();

    private void Start()
    {
        LoadBitMap();
    }

    //Color32 gives good precision to color checks
    public void LoadBitMap()
    {

        Resources.UnloadUnusedAssets();

        Dictionary<Color32, Texture2D> textures = new Dictionary<Color32, Texture2D>();

        Color32 defaultColor = new Color32(255, 255, 255, 255);

        int width = image.texture.width;
        int height = image.texture.height;

        Texture2D sampleTexture = new Texture2D(width, height);

        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                sampleTexture.SetPixel(x, y, new Color(1,1,1,0));
            }
        }

        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {

                Color32 color = image.texture.GetPixel(x, y);

                if (textures.ContainsKey(color))
                {
                    textures[color].SetPixel(x, y, defaultColor);
                }
                else
                {
                    var provinceTex = Texture2D.Instantiate(sampleTexture);
                    provinceTex.SetPixel(x, y, defaultColor);
                    textures.Add(color, provinceTex);
                }
            }
        }

        int index = 0;

        foreach (var texture in textures)
        {
            texture.Value.Apply();
            var finalSprite = Sprite.Create(texture.Value, new Rect(0, 0, texture.Value.width, texture.Value.height), new Vector2(0.5f, 0.5f));
            finalSprite.name = $"Province Sprite {index}";

            GameObject sprite = Instantiate(provinceObject);

            sprite.transform.position = new Vector3(sprite.transform.position.x, sprite.transform.position.y, 0.5f);

            sprite.transform.SetParent(spritesParent.transform);

            sprites.Add(finalSprite);
            spriteObjects.Add(texture.Key, sprite);
            index++;
        }

        index = 0;

        foreach (var obj in spriteObjects)
        {
            obj.Value.GetComponent<SpriteRenderer>().sprite = sprites[index];
            index++;
        }

        GameEventHub.ProvinceCreation.Provinces = spriteObjects;
        onProvincesCreatedEvent?.Invoke();

    }
}
