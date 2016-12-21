using UnityEngine;
using System.Collections;
using DG.Tweening;

public class ClickChangeStatusMove : ClickChangeStatus
{
    [Tooltip("想要移动的物体，不填则为自身")]
    public Transform targetMove;
    [Tooltip("想要移动到哪里")]
    public Transform moveTo;
    [Tooltip("是否平滑移动")]
    public bool isMoveSmoothly;
    [Tooltip("平滑移动时间")]
    public float smoothlyMoveDuration = 0.3f;

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
        if (isMoveSmoothly)
        {
            var movePos = GameObjectInfo.Status == TargetStatus ? moveToVector3 : originalPos;
            transform.DOMove(movePos, smoothlyMoveDuration);
        }
        else
        {
            //根据状态移动
            transform.position = GameObjectInfo.Status == TargetStatus ? moveToVector3 : originalPos;
        }
    }

    public override void Reset()
    {
        base.Reset();
        //还原到原始位置
        targetMove.position = originalPos;
    }
}
