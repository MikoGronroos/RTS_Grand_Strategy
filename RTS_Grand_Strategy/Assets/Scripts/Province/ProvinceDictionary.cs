using System.Collections.Generic;
using UnityEngine;

public class ProvinceDictionary : MonoBehaviour
{

    private static Dictionary<int, ProvinceHolder> allProvinces = new Dictionary<int, ProvinceHolder>();

    [SerializeField] private List<ProvinceHolder> provincesList = new List<ProvinceHolder>();

    [SerializeField] private GameEvent onProvincesLoaded;

    public void LoadProvinces()
    {
        ProvinceHolder[] provinces = FindObjectsOfType<ProvinceHolder>();

        foreach (var province in provinces)
        {
            allProvinces.Add(province.ThisProvince.ProvinceId, province);
        }

        onProvincesLoaded?.Invoke();

    }

    public static ProvinceHolder GetProvinceFromDictionary(int id)
    {

        if (allProvinces.ContainsKey(id))
        {
            return allProvinces[id];
        }
        return null;
    }
}
