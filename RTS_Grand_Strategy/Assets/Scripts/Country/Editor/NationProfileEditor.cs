using UnityEngine;
using UnityEditor;


#if UNITY_EDITOR
[CustomEditor(typeof(NationProfile))]
public class NationProfileEditor : Editor
{

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        var nationProfile = (NationProfile)target;

        if (nationProfile == null) return;

        if (GUILayout.Button("Set To Local Nation"))
        {
            nationProfile.LocalPlayer = true;
        }

    }
}
#endif