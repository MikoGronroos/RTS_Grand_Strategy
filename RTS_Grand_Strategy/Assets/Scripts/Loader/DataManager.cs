using System;
using UnityEngine;

public class DataManager : MonoBehaviour
{

    public static Action OnDataLoading;

    private void Start()
    {
        LoadData();
    }

    public void LoadData()
    {
        OnDataLoading?.Invoke();
    }

}
