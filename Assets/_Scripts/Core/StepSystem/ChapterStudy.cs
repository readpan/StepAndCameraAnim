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
                ChapterStartup();
                break;
            case 102:
                ChapterShutdown();
                break;
            default:
                break;
        }
    }

    private void ChapterStartup()
    {
        steps = null;
        steps = new List<Step>();
        steps.Add(new Step("", 1087645189, 5));
        steps.Add(new Step("配电箱。", 1321559355, 5, "Radar_Startup_PeiDianXiang"));
        steps.Add(new Step("电脑机柜。", 2054650885, 5, "Radar_Startup_RDAJiGui"));
        steps.Add(new Step("发射机柜。", 1123024661, 5, "Radar_Startup_FaSheJiXiang"));
        steps.Add(new Step("1.配电箱：按下启动键.点击红色的启动项按钮", 520227936, Enum_GameObjectStatus.SwitchOn, "Radar_Startup_000"));
        steps.Add(new Step("2.配电箱：打开接收机电源.开关由下向上推 上面黄色灯亮", 1132878191, Enum_GameObjectStatus.SwitchOn, "Radar_Startup_001", PlayMode.Start, false));
        steps.Add(new Step("3.配电箱：打开RDA电源.开关由下向上推 上面黄色灯亮", 166211606, Enum_GameObjectStatus.SwitchOn, "Radar_Startup_002", PlayMode.Start, false));
        steps.Add(new Step("4.配电箱：打开发射机.打开发射机1", 1680334727, Enum_GameObjectStatus.SwitchOn, "Radar_Startup_003", PlayMode.Start, false));
        steps.Add(new Step("打开发射机2", 1479903111, Enum_GameObjectStatus.SwitchOn, "", PlayMode.Stop, false));
        steps.Add(new Step("打开发射机3", 1083889391, Enum_GameObjectStatus.SwitchOn, "", PlayMode.Stop, false));
        steps.Add(new Step("", 2054650885, 5, "", PlayMode.Stop));//电脑机柜
        steps.Add(new Step("5.电脑机柜：打开计算机.按下开机键", 559050764, Enum_GameObjectStatus.SwitchOn, "Radar_Startup_004"));
        steps.Add(new Step("6.电脑机柜：打开DAU电源.向上推开关，打开DAU电源", 1861012354, Enum_GameObjectStatus.SwitchOn, "Radar_Startup_005"));
        steps.Add(new Step("7.电脑机柜：打开伺服电源.向上推开关，打开伺服电源", 1539773313, Enum_GameObjectStatus.SwitchOn, "Radar_Startup_006"));
        steps.Add(new Step("", 1123024661, 5, "", PlayMode.Stop));//发射机柜
        steps.Add(new Step("8.发射箱：机柜供电.向上推开关，打开机柜供电", 239833176, Enum_GameObjectStatus.SwitchOn, "Radar_Startup_007"));
        steps.Add(new Step("9.发射机：辅助供电.向上推开关，打开辅助供电", 1717942894, Enum_GameObjectStatus.SwitchOn, "Radar_Startup_008"));
        steps.Add(new Step("", 1321559355, 5, "", PlayMode.Stop));//配电箱。
        steps.Add(new Step("10.配电箱：伺服功能外放.伺服功能外放1", 2052902562, Enum_GameObjectStatus.SwitchOn, "Radar_Startup_009"));
        steps.Add(new Step("伺服功能外放2", 1715264242, Enum_GameObjectStatus.SwitchOn, "", PlayMode.Continue, false));
        steps.Add(new Step("伺服功能外放3", 468960565, Enum_GameObjectStatus.SwitchOn, "", PlayMode.Continue, false));
        PressKeyToGo("11.发射机：13分钟后，观察发射机柜的：“风流量”、“故障”灯亮", "Radar_Startup_010", PlayMode.Start, true, () => { MeditorManager.Instance.MeditorUi.ShowClock(); });
        steps.Add(new Step("", 1123024661, 5, "", PlayMode.Continue));//发射机柜
        {
            //飞到观察灯,灯亮
            Step s = new Step("", 1636733605, 0.1f, "", PlayMode.Continue);
            s.StepStartAutoAction += () =>
            {
                GameObjectInfoManager.Instance.GameObjectInfosDic[1636733605].Status = Enum_GameObjectStatus.SwitchOn;
            };
            steps.Add(s);

        }
        PressKeyToGo("观察灯亮是否亮", "", PlayMode.Continue);
        steps.Add(new Step("12.发射机：灯亮后开“高压供电.向上推开关，打开高压供电", 326743299, Enum_GameObjectStatus.SwitchOn, "Radar_Startup_011"));
        steps.Add(new Step("13.发射机：按“故障显示复位”“手动复位”按钮，“故障”“风流量”灯灭.按“故障显示复位”", 1358187416, Enum_GameObjectStatus.SwitchOn, "Radar_Startup_012"));
        steps.Add(new Step("按“手动复位", 1955476218, Enum_GameObjectStatus.SwitchOn, "", PlayMode.Continue, false));
        PressKeyToGo("14.电脑机柜：启动RDASC程序", "Radar_Startup_013", PlayMode.Start, true, () =>
          {
              Application.ExternalCall(ToWebFunctionStrings.popupEquipMainten, "radar");
          });
        PressKeyToGo("结束", "", PlayMode.Stop);
        StartCoroutine("StartSteps");
    }
    private void ChapterShutdown()
    {
        //开始时候配置
        int[] ids = new[]
        {
            1717942894, 1539773313, 2052902562, 1715264242, 468960565,
            1861012354, 559050764, 166211606, 1132878191, 1680334727, 1479903111, 1083889391, 239833176
        };
        for (int i = 0; i < ids.Length; i++)
        {
            GameObjectInfoManager.Instance.GameObjectInfosDic[ids[i]].Status = Enum_GameObjectStatus.SwitchOn;
        }

        steps = null;
        steps = new List<Step>();
        PressKeyToGo("1.电脑机柜：退出RDASC程序", "", PlayMode.Start, true, () =>
          {
              Application.ExternalCall(ToWebFunctionStrings.popupEquipMainten, "radar_tuichu");
          });
        steps.Add(new Step("2.发射机：辅助供电.向下推开关，关闭辅助供电", 1717942894, Enum_GameObjectStatus.SwitchOff, ""));
        steps.Add(new Step("3.电脑机柜：向下推开关，关闭伺服电源", 1539773313, Enum_GameObjectStatus.SwitchOff, ""));
        steps.Add(new Step("4.配电箱：伺服功能外放.关闭伺服功能外放1", 2052902562, Enum_GameObjectStatus.SwitchOff, ""));
        steps.Add(new Step("关闭伺服功能外放2", 1715264242, Enum_GameObjectStatus.SwitchOff, "", PlayMode.Stop, false));
        steps.Add(new Step("关闭伺服功能外放3", 468960565, Enum_GameObjectStatus.SwitchOff, "", PlayMode.Stop, false));
        steps.Add(new Step("5.电脑机柜：向下推开关，关闭DAU电源", 1861012354, Enum_GameObjectStatus.SwitchOff, ""));
        steps.Add(new Step("6.电脑机柜：关闭计算机", 559050764, Enum_GameObjectStatus.SwitchOff, ""));
        steps.Add(new Step("7.配电箱：关闭RDA电源，开关由上向下推 上面黄色灯灭", 166211606, Enum_GameObjectStatus.SwitchOff, ""));
        steps.Add(new Step("7.配电箱：关闭接收机电源，开关由上向下推 上面黄色灯灭", 1132878191, Enum_GameObjectStatus.SwitchOff, ""));
        PressKeyToGo("大约在半小时侯，检查聚焦线圈的温度，在聚焦线圈变凉后，可以关闭“高压供电”", "");
        steps.Add(new Step("关闭发射机1", 1680334727, Enum_GameObjectStatus.SwitchOff, ""));
        steps.Add(new Step("关闭发射机2", 1479903111, Enum_GameObjectStatus.SwitchOff, "", PlayMode.Stop, false));
        steps.Add(new Step("关闭发射机3", 1083889391, Enum_GameObjectStatus.SwitchOff, "", PlayMode.Stop, false));
        steps.Add(new Step("发射箱：机柜供电。向下推开关，关闭机柜供电", 239833176, Enum_GameObjectStatus.SwitchOff, ""));
        PressKeyToGo("结束", "");
        StartCoroutine("StartSteps");
    }
    private void PressKeyToGo(string subtitle, Action endAction = null)
    {
        PressKeyToGo(subtitle, "", PlayMode.Start, false, endAction);
    }
    private void PressKeyToGo(string subtitle, string audioName, PlayMode playMode = PlayMode.Start, bool autoCameraAnim = true, Action endAction = null, Action startAction = null)
    {
        Step s = new Step(subtitle, 921922207, Enum_GameObjectStatus.PressKey, audioName, playMode, autoCameraAnim);
        s.IsPressStep = true;
        s.StepStartAutoAction += () =>
        {
            //让UI启动图标
            MeditorManager.Instance.MeditorUi.SetPressIcon();
            if (startAction != null)
            {
                startAction();
            }
        };
        s.StepEndautoAction +=
            () =>
            {
                if (endAction != null)
                {
                    endAction();
                }
                GameObjectInfoManager.Instance.GameObjectInfosDic[921922207].Status = Enum_GameObjectStatus.Normal;
            };
        steps.Add(s);
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
                ChapterStartup();
            }
            if (GUILayout.Button("Start Chapter Two"))
            {
                if (StudyManager.Instance.OnStartStudy != null)
                    StudyManager.Instance.OnStartStudy();
                ChapterShutdown();
            }
        }
    }
}
