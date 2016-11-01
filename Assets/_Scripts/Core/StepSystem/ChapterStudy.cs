using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// 具体配置章节的
/// </summary>
public class ChapterStudy : StudyBase
{
    private bool _testButton;
    public int CurrentChapterIndex;
    protected override void Start()
    {
        base.Start();
        OnGUIManager.Instance.OnGuiAction += OnGUIChapterStudy;
    }

    public void StartChapter(int chapterIndex)
    {
        CurrentChapterIndex = chapterIndex;
        switch (chapterIndex)
        {
            case 101:
                ChapterOne();
                break;
            case 102:
                ChapterTwo();
                break;
            default:
                break;
        }
    }

    private void ChapterOne()
    {
        steps = null;
        steps = new List<Step>();
        steps.Add(new Step(1312623178, Enum_GameObjectStatus.SwitchOn, "Radar_Startup_002"));
        {
            Step s = new Step(880672262, Enum_GameObjectStatus.SwitchOn, "Radar_Startup_010");
            s.StepStartAutoAction += () =>
            {
                Debug.Log("Auto Do!");
            };
            steps.Add(s);
        }
        steps.Add(new Step(1022588476, Enum_GameObjectStatus.SwitchOn, "Radar_Startup_001"));
        StartCoroutine("StartSteps");
    }

    private void ChapterTwo()
    {
        steps = null;
        steps = new List<Step>();
        steps.Add(new Step(1312623178, Enum_GameObjectStatus.SwitchOn, "Radar_Startup_002"));
        {
            Step s = new Step(880672262, Enum_GameObjectStatus.SwitchOn, "Radar_Startup_020");
            s.StepStartAutoAction += () =>
            {
                Debug.Log("Auto Do!");
            };
            steps.Add(s);
        }
        steps.Add(new Step(1022588476, Enum_GameObjectStatus.SwitchOn, "Radar_Startup_001"));
        StartCoroutine("StartSteps");
    }

    public void OnGUIChapterStudy()
    {
        if (GUILayout.Button("__ChapterStudy"))
        {
            _testButton = !_testButton;
        }
        if (_testButton)
        {
            if (GUILayout.Button("Start Chapter One"))
            {
                if (StudyManager.Instance.OnStartStudy != null)
                    StudyManager.Instance.OnStartStudy();
                ChapterOne();
            }
            if (GUILayout.Button("Start Chapter Two"))
            {
                if (StudyManager.Instance.OnStartStudy != null)
                    StudyManager.Instance.OnStartStudy();
                ChapterTwo();
            }
        }
    }
}
