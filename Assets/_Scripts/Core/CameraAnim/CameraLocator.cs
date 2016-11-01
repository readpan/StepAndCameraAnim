using UnityEngine;
using System.Collections;
using DG.Tweening;

public class CameraLocator : MonoBehaviour
{
    [Tooltip("相机目标,默认为main camera")]
    public Transform TargetCamera;
    [Tooltip("这段摄像机动画的时间,默认为3秒")]
    public float MoveDuration = 1f;
    [Tooltip("摄像机转向目标的速度")]
    public float CameraRotateSpeed = 0.3f;

    //移动的路径
    private Vector3[] _paths;

    public void Awake()
    {
        if (TargetCamera == null)
            TargetCamera = Camera.main.transform;
        //获取路径
        var cameraPaths = GetComponentsInChildren<CameraPath>();
        _paths = new Vector3[cameraPaths.Length];
        for (int i = 0; i < cameraPaths.Length; i++)
        {
            _paths[i] = cameraPaths[i].transform.position;
        }
    }

    /// <summary>
    /// 执行摄像机动画
    /// </summary>
    public void DoLocator()
    {
        if (CameraManager.Instance.OnCameraAnimStartAction != null)
        {
            CameraManager.Instance.OnCameraAnimStartAction(gameObject);
        }
        TargetCamera.DOKill();
        //先看向物体
        TargetCamera.DOLookAt(transform.position, CameraRotateSpeed);
        //然后按照路径进行运动
        TargetCamera.DOPath(_paths, MoveDuration).SetDelay(CameraRotateSpeed).OnComplete(() =>
        {
            //最终LookAt物体
            TargetCamera.DOLookAt(transform.position, CameraRotateSpeed).OnComplete(() =>
            {
                if (CameraManager.Instance.OnCameraAnimOverAction != null)
                {
                    CameraManager.Instance.OnCameraAnimOverAction(gameObject);
                }
            });
        });

        //在动画过程中会一直看着物体,但是效果不好, 会导致Z轴倾斜
        //TargetCamera.DOPath(_paths, MoveDuration).SetDelay(CameraRotateSpeed).OnComplete(() =>
        //      {
        //          //TargetCamera.eulerAngles = new Vector3(TargetCamera.eulerAngles.x, TargetCamera.eulerAngles.y, 0);
        //          TargetCamera.DORotate(new Vector3(TargetCamera.eulerAngles.x, TargetCamera.eulerAngles.y, 0), CameraRotateSpeed).OnComplete(
        //              () =>
        //              {

        //              });
        //          if (CameraManager.Instance.OnCameraAnimOverAction != null)
        //          {
        //              CameraManager.Instance.OnCameraAnimOverAction(gameObject);
        //          }
        //      }).SetLookAt(transform);

    }
}
