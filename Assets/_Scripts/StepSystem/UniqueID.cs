using UnityEngine;
using System.Collections;
using System;
/// <summary>
/// 随机生成物体的唯一ID号，用于设定物体状态，智能提示查找物体位置等
/// </summary>
[ExecuteInEditMode]
public class UniqueID : MonoBehaviour
{
    public int uniqueID = 0;
    void Awake()
    {
        if (uniqueID == 0)
        {
            uniqueID = GenerateId();
        }
    }

    void Start()
    {
        SetID();
    }
    /// <summary>
    /// 功能菜单，重置物体ID号，谨慎使用
    /// </summary>
    [ContextMenu("ResetID")]
    void ResetID()
    {
        uniqueID = GenerateId();
        SetID();
    }
    /// <summary>
    /// 设定物体的ID
    /// </summary>
    void SetID()
    {
        GameObjectInfo gameObjectInfo = GetComponent<GameObjectInfo>();

        if (null != gameObjectInfo)
        {
            gameObjectInfo.UniqueId = uniqueID;
        }
    }

    public int GetID()
    {
        return uniqueID;
    }
    /// <summary>
    /// 全局函数，生成唯一的物体标识
    /// </summary>
    /// <returns></returns>
    public static int GenerateId()
    {
        byte[] buffer = Guid.NewGuid().ToByteArray();
        while (BitConverter.ToInt32(buffer, 0) < 0)
            buffer = Guid.NewGuid().ToByteArray();
        return BitConverter.ToInt32(buffer, 0);
    }
}
