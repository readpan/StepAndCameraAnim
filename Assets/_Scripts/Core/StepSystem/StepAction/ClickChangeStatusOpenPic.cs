using UnityEngine;
using System.Collections;

public class ClickChangeStatusOpenPic : ClickChangeStatus
{
    public MeshRenderer targetMesh;
    private Texture _originalTexture;
    public Texture TargetTexture;
    public override void Awake()
    {
        base.Awake();
        _originalTexture = targetMesh.material.mainTexture;
    }

    public override void OnMouseUp()
    {
        base.OnMouseUp();
        if (targetMesh != null)
        {
            targetMesh.material.mainTexture = TargetStatus == Enum_GameObjectStatus.SwitchOn ? TargetTexture : _originalTexture;
        }
    }
}
