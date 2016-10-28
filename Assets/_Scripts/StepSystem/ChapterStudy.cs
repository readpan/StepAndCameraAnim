using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// 具体配置章节的
/// </summary>
public class ChapterStudy : MonoBehaviour
{
    private List<Step> steps;
    private int index;
    public Action OnChapterOver;
    public void Start()
    {
        OnChapterOver += DoChapterOver;
    }

    private void ChapterOne()
    {
        steps = new List<Step>();
        {
            Step s = new Step(880672262, Enum_GameObjectStatus.SwitchOff);
            s.StepAutoAction += () =>
            {
                Debug.Log("Auto Do!");
            };
            steps.Add(s);
        }
        steps.Add(new Step(1022588476, Enum_GameObjectStatus.SwitchOff));
        steps.Add(new Step(1312623178, Enum_GameObjectStatus.SwitchOff));
        StartCoroutine("StartSteps");
    }

    IEnumerator StartSteps()
    {
        while (true)
        {
            steps[index].StartStep();
            if (steps[index].StepAutoAction != null)
            {
                steps[index].StepAutoAction();
            }
            yield return new WaitWhile(() => steps[index].keepWaiting);
            index++;
            if (index >= steps.Count)
            {
                //章节操作结束
                if (OnChapterOver != null)
                    OnChapterOver();
                break;
            }
        }
    }

    private void DoChapterOver()
    {
        index = 0;
        Debug.Log("Chapter is over");
    }

    public void OnGUI()
    {
        if (GUILayout.Button("Start Chapter"))
        {
            ChapterOne();
        }
    }
}
