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
            if (OnGuiAction != null)
            {
                OnGuiAction();
            }
        }
    }
}
