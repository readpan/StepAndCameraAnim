using System;
using UnityEngine;
using System.Collections;
using Pan_Tools;

public class OnGUIManager : MonoSingleton<OnGUIManager>
{
    public bool DebugMode = false;
    public Action OnGuiAction;

    public void OnGUI()
    {
        if (DebugMode)
        {
            if (GUILayout.Button("清理缓存"))
            {
                Caching.CleanCache();
                Debug.Log("缓存已清理.");
            }
            if (OnGuiAction != null)
            {
                OnGuiAction();
            }
        }
    }
}
