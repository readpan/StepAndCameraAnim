//--------------
//这个脚本是用来操作相机对目标物体视角的, 如缩放,旋转,平移
using UnityEngine;

public class MouseFollowRotation : MonoBehaviour
{

    public Transform target;
    public float xSpeed = 200, ySpeed = 200, mSpeed = 10;
    public float yMinLimit = -50, yMaxLimit = 50;
    public float distance = 7, minDistance = 2, maxDistance = 30;

    //bool needDamping = false;  
    public bool needDamping = true;
    float damping = 10f;

    public float RotateX = 0.0f;
    public float RotateY = 0.0f;
    private Vector3 translateVector3;

    /// <summary>
    /// 是否在自己的控制下
    /// </summary>
    private bool isUnderControll;

    public void SetIsUnderControll(bool controllable)
    {
        isUnderControll = controllable;
    }

    public void SetTarget(GameObject go)
    {
        target = go.transform;
    }
    void Start()
    {
        //订阅Camera动画事件
        CameraManager.Instance.OnCameraAnimStartAction += DoAnimStartAction;
        CameraManager.Instance.OnCameraAnimOverAction += DoAnimOverAction;
        translateVector3 = Vector3.zero;
    }
    //动画开始事件
    private void DoAnimStartAction(GameObject targetGameObject)
    {
        target = targetGameObject.transform;
        //target = CameraManager.Instance.TargetLookAtTransform.transform;
        SetIsUnderControll(false);
    }
    //动画结束事件
    private void DoAnimOverAction(GameObject targetGameObject)
    {
        SetIsUnderControll(true);
        UpdatePos();
    }

    //从新定位到一个目标以及新位置时候, 调用,更新参数
    private void UpdatePos()
    {
        Vector3 angles = transform.eulerAngles;
        RotateX = angles.y;
        RotateY = angles.x;
        translateVector3 = Vector3.zero;
        //更新摄像机位置
        distance = Vector3.Distance(transform.position, CameraManager.Instance.TargetLookAtTransform.position);
    }
    void LateUpdate()
    {
        if (isUnderControll)
        {
            if (target)
            {
                if (Input.GetMouseButton(0))
                {
                    RotateX += Input.GetAxis("Mouse X") * xSpeed * 0.02f;
                    RotateY -= Input.GetAxis("Mouse Y") * ySpeed * 0.02f;
                    RotateY = ClampAngle(RotateY, yMinLimit, yMaxLimit);
                }
                if (Input.GetMouseButton(2))
                {
                    translateVector3.x += -Input.GetAxis("Mouse X");
                    translateVector3.y += -Input.GetAxis("Mouse Y");
                    //CameraManager.Instance.MoveTargetPos(translateVector3.x, translateVector3.y, translateVector3.z);
                    //UpdatePos();
                }
                else
                {
                    //translateVector3 = Vector3.zero;
                }

                distance -= Input.GetAxis("Mouse ScrollWheel") * mSpeed;
                distance = Mathf.Clamp(distance, minDistance, maxDistance);
                Quaternion rotation = Quaternion.Euler(RotateY, RotateX, 0.0f);
                Vector3 disVector = new Vector3(0.0f, 0.0f, -distance);
                Vector3 position = rotation * disVector + target.position + transform.right * translateVector3.x + transform.up * translateVector3.y;
                //adjust the camera  
                if (needDamping)
                {
                    transform.rotation = Quaternion.Lerp(transform.rotation, rotation, Time.deltaTime * damping);
                    transform.position = Vector3.Lerp(transform.position, position, Time.deltaTime * damping);
                }
                else
                {
                    transform.rotation = rotation;
                    transform.position = position;
                }
            }

        }
    }

    static float ClampAngle(float angle, float min, float max)
    {
        if (angle < -360)
            angle += 360;
        if (angle > 360)
            angle -= 360;
        return Mathf.Clamp(angle, min, max);
    }
}

