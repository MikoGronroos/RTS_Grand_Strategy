using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class InitializeProvinces : MonoBehaviour
{


    [SerializeField] private string provinceDataPath;

    [SerializeField] private List<ProvinceData> provinceData = new List<ProvinceData>();

    [SerializeField] private GameEvent onProvincesInitialized;

    public void Initialize()
    {
        Resources.UnloadUnusedAssets();

        Dictionary<Color32, GameObject> data = GameEventHub.ProvinceCreation.Provinces;

        foreach (string line in File.ReadAllLines(Application.persistentDataPath + provinceDataPath))
        {
            Color firstColor = new Color();
            string[] dataSplit = line.Split(';');

            int id = int.Parse(dataSplit[0]);

            firstColor.r = int.Parse(dataSplit[1]) / 255.0f;
            firstColor.g = int.Parse(dataSplit[2]) / 255.0f;
            firstColor.b = int.Parse(dataSplit[3]) / 255.0f;
            firstColor.a = 1;

            string type = dataSplit[4];

            float x = float.Parse(dataSplit[5]);
            float y = float.Parse(dataSplit[6]);

            string[] coreNationIdsSplit = dataSplit[7].Split(',');

            ProvinceData newData = new ProvinceData(firstColor, id, type, x, y, coreNationIdsSplit);

            provinceData.Add(newData);
        }

        foreach (var province in data)
        {

            province.Value.AddComponent<PolygonCollider2D>();

            for (int i = 0; i < provinceData.Count; i++)
            {

                Color32 color = provinceData[i].ProvinceColor;

                if (color.Equals(province.Key))
                {
                    var holder = province.Value.GetComponent<ProvinceHolder>();
                    holder.ThisProvince.ProvinceId = provinceData[i].ProvinceID;
                    holder.SetMovementPointPos(provinceData[i].MovementPosition);
                    holder.ThisProvince.coreNationIds = provinceData[i].coreNationIds;
                }
            }
        }

        onProvincesInitialized?.Invoke();

    }
}
