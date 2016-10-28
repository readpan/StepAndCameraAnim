using UnityEngine;
using System.Collections;

public class CameraControllerRotateScale : MonoBehaviour {

    public Vector3 Targetdistance = new Vector3(0, 0, -5);

    public float x_speed = 5f;
    public float y_speed = 5f;

    private Vector3 rota;

    public Transform target;

    public float ScaleSpeed = 5;

    private Quaternion q;

    // Use this for initialization  
    IEnumerator Start()
    {
        rota = transform.eulerAngles;
        transform.position = target.position + Targetdistance;
        yield return new WaitForEndOfFrame();
        Rotate();
    }

    // Update is called once per frame  
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Rotate();
        }
        Scale();
    }

    private void Rotate()
    {
        rota.y += Input.GetAxis("Mouse X") * x_speed;
        rota.x -= Input.GetAxis("Mouse Y") * y_speed;
        rota.x = Mathf.Clamp(rota.x, -20, 80);
        q = Quaternion.Euler(rota);
        transform.rotation = q;
    }

    private void Scale()
    {
        Targetdistance.z += Input.GetAxis("Mouse ScrollWheel") * ScaleSpeed;
        if (Targetdistance.z > -0.4f)
            Targetdistance.z = -0.4f;
        transform.position = q * Targetdistance + target.position;
    }
}
