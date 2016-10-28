using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// 具体配置章节的
/// </summary>
public class ChapterStudy : StudyBase
{
    private void ChapterOne()
    {
        steps = new List<Step>();
        {
            Step s = new Step(880672262, Enum_GameObjectStatus.SwitchOff);
            s.StepStartAutoAction += () =>
            {
                Debug.Log("Auto Do!");
            };
            steps.Add(s);
        }
        steps.Add(new Step(1022588476, Enum_GameObjectStatus.SwitchOff));
        steps.Add(new Step(1312623178, Enum_GameObjectStatus.SwitchOff));
        StartCoroutine("StartSteps");
    }

    public void OnGUI()
    {
        if (GUILayout.Button("Start Chapter"))
        {
            ChapterOne();
        }
    }
}
