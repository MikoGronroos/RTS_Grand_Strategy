using UnityEngine;

[System.Serializable]
public class Province
{

    [SerializeField] private string provinceOwnerID;

    public int ProvinceStateID;

    public string ProvinceName;

    public int ProvinceId;

    public string ProvinceOwnerID {
        get
        {
            return provinceOwnerID;
        }
        set
        {
            provinceOwnerID = value;
        }
    }

}
