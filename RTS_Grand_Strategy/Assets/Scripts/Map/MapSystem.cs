using UnityEngine;

public class MapSystem : MonoBehaviour
{

    [SerializeField] private Sprite map;
    [SerializeField] private GameObject mapPrefab;

    private void Start()
    {
        GameObject imageObject = Instantiate(mapPrefab);
        imageObject.transform.position = Vector3.zero;

        var mapScript = imageObject.GetComponent<MapObject>();
        mapScript.GetSpriteRenderer().sprite = map;
        
    }

}
