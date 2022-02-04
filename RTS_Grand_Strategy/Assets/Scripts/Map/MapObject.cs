using UnityEngine;

public class MapObject : MonoBehaviour
{

    [SerializeField] private SpriteRenderer spriteRenderer;

    private void Start()
    {
        gameObject.AddComponent<BoxCollider2D>();
    }

    public SpriteRenderer GetSpriteRenderer()
    {
        return spriteRenderer;
    }

    public Color32 GetPixel(int x, int y)
    {
        return spriteRenderer.sprite.texture.GetPixel(x,y);
    }

    private void OnMouseDown()
    {
    }

}