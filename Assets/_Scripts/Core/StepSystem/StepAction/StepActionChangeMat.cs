using UnityEngine;
using System.Collections;

public class StepActionChangeMat : MonoBehaviour
{
    private GameObjectInfo gameObjectInfo;
    public MeshRenderer MeshRenderer;

    private Material OrginalMaterial;
    public Material TargetMaterial;

    public void Awake()
    {
        gameObjectInfo = GetComponent<GameObjectInfo>();
        if (MeshRenderer == null)
            MeshRenderer = GetComponent<MeshRenderer>();
        OrginalMaterial = MeshRenderer.material;
    }

    public void Start()
    {
        gameObjectInfo.OnStatusChangeAction += SwitchMat;
    }

    public void SwitchMat()
    {
        MeshRenderer.material = gameObjectInfo.Status == Enum_GameObjectStatus.SwitchOn ? TargetMaterial : OrginalMaterial;
    }

}
