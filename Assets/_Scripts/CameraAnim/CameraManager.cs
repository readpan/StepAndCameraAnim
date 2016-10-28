using System;
using UnityEngine;
using System.Collections;

public class CameraManager : /*MonoSingleton<CameraManager>*/MonoBehaviour
{
    private static CameraManager instance;

    public static CameraManager Instance
    {

        get
        {
            if (instance == null)
                instance = FindObjectOfType<CameraManager>();
            //todo 可以新建一个物体
            if (instance == null)
            {
                Debug.LogError("Can't Find GameObject with CameraManger component.");
                return null;
            }
            return instance;
        }
    }

    /// <summary>
    /// 摄像机开始动画回调
    /// </summary>
    public Action<GameObject> OnCameraAnimStartAction;

    /// <summary>
    /// 摄像机动画运动结束回调
    /// </summary>
    public Action<GameObject> OnCameraAnimOverAction;

    /// <summary>
    /// 摄像机是否可以被玩家控制
    /// </summary>
    public bool CameraControllByPlayer;

    /// <summary>
    /// 摄像机LookAt的目标
    /// </summary>
    public Transform TargetLookAtTransform;

    /// <summary>
    /// 鼠标旋转缩放平移控制器
    /// </summary>
    public MouseFollowRotation MouseFollowRotation;

    public void Awake()
    {
        MouseFollowRotation = GetComponent<MouseFollowRotation>();
    }

    public void Start()
    {
        TargetLookAtTransform = transform;
        OnCameraAnimStartAction += DoCameraAnimStart;
        OnCameraAnimOverAction += DoCameraAnimOver;
    }

    //定位结束
    private void DoCameraAnimOver(GameObject target)
    {
        CameraControllByPlayer = false;
        Debug.Log(target.name + "'s Camera Anim is over!");
    }
    //开始定位
    private void DoCameraAnimStart(GameObject target)
    {
        CameraControllByPlayer = true;
        TargetLookAtTransform = target.transform;
        //TargetLookAtTransform.position = target.transform.position;
        //TargetRotateTransform.position = target.transform.position;
        Debug.Log(target.name + "'s Camera Anim is start!");
    }

    public void OnDestroy()
    {
        OnCameraAnimStartAction = null;
        OnCameraAnimOverAction = null;
    }

    public void MoveTargetPos(float x, float y, float z)
    {
        TargetLookAtTransform.position = new Vector3(x, y, z);
    }
}
