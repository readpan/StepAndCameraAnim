using UnityEngine;
using System.Collections;
using Pan_Tools;

public class MeditorManager : MonoSingleton<MeditorManager>
{
    public MeditorUI MeditorUi;

    public void Awake()
    {
        MeditorUi = Global.FindChild<MeditorUI>(transform, "MeditorUI");
    }
}
