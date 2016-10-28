using UnityEngine;
using System.Collections;

public class OnGuiButtons : MonoBehaviour
{
    public CameraLocator[] l;

    public void OnGUI()
    {
        for (int i = 0; i < l.Length; i++)
        {
            if (GUILayout.Button("Play " + l + i))
            {
                l[i].DoLocator();
            }
        }
    }
}
