using System;
using UnityEngine;
using System.Collections;
using Pan_Tools;

public class InputManager : MonoSingleton<InputManager>
{

    public Action OnClickContinue;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    public void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space) || Input.GetKeyUp(KeyCode.KeypadEnter))
        {
            if (StudyManager.Instance.CurrentStep.IsPressStep)
            {
                if (OnClickContinue != null)
                {
                    OnClickContinue();
                }
            }
        }
    }
}
