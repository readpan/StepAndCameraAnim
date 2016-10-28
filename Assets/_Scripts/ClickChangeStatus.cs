using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Collider))]
[RequireComponent(typeof(GameObjectInfo))]
public class ClickChangeStatus : MonoBehaviour
{
    [Tooltip("点击后想要改变的状态")]
    public Enum_GameObjectStatus targetStatus;

    private GameObjectInfo gameObjectInfo;

    public void Awake()
    {
        gameObjectInfo = GetComponent<GameObjectInfo>();
    }
    public void OnMouseUp()
    {
        gameObjectInfo.Status = targetStatus;
    }
}
