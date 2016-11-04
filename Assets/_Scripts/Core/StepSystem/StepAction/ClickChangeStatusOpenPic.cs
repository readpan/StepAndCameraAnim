using UnityEngine;
using System.Collections;

public class ClickChangeStatusOpenPic : ClickChangeStatus
{
    public MeshRenderer targetMesh;
    private Texture _originalTexture;
    public Texture TargetTexture;
    private Enum_GameObjectStatus _originalStatus;
    public override void Awake()
    {
        base.Awake();
        _originalTexture = targetMesh.material.mainTexture;
        _originalStatus = GameObjectInfo.Status;
    }

    protected override void Start()
    {
        base.Start();
        GameObjectInfo.OnStatusChangeAction += StatusChanged;
    }

    public override void OnMouseUp()
    {
        GameObjectInfo.Status = GameObjectInfo.Status == TargetStatus ? _originalStatus : TargetStatus;
        if (targetMesh != null)
        {
            targetMesh.material.mainTexture = TargetStatus == Enum_GameObjectStatus.SwitchOn ? TargetTexture : _originalTexture;
        }
    }

    private void StatusChanged()
    {
        targetMesh.material.mainTexture = GameObjectInfo.Status == Enum_GameObjectStatus.SwitchOn ? TargetTexture : _originalTexture;
    }
}
