using System;
using UnityEngine;

namespace Pan_Tools
{
    public class CaptureSuperImage : MonoBehaviour
    {

        [Header("放大倍数")]
        public int size = 1;
        // Use this for initialization

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.F9))
            {
                Debug.Log(DateTime.Now + "Has Print");
                Application.CaptureScreenshot(Application.persistentDataPath + "/" + DateTime.Now.Year + "_" + DateTime.Now.Month + "_" + DateTime.Now.Day + "_" + DateTime.Now.Hour + "_" + DateTime.Now.Minute + "_" + DateTime.Now.Second + "_" + "Capture.png", size);
            }
        }
    }
}
