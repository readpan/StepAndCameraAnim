using UnityEngine;
using System.Collections;

public class ClickChangeStatusMove : ClickChangeStatus
{
    [Tooltip("想要移动的物体，不填则为自身")]
    public Transform targetMove;
    [Tooltip("想要移动到哪里")]
    public Transform moveTo;

    private Vector3 moveToVector3;

    private Vector3 originalPos;

    public override void Awake()
    {
        base.Awake();
        if (targetMove == null)
        {
            targetMove = transform;
        }
        originalPos = targetMove.position;
        moveToVector3 = moveTo.position;
    }

    public override void OnMouseUp()
    {
        base.OnMouseUp();
        //根据状态移动
        transform.position = GameObjectInfo.Status == TargetStatus ? moveToVector3 : originalPos;
    }

    public override void Reset()
    {
        base.Reset();
        //还原到原始位置
        targetMove.position = originalPos;
    }
}
