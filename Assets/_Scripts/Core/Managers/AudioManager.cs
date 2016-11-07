﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using DG.Tweening;
using Pan_Tools;

public class AudioManager : MonoSingleton<AudioManager>, IReset
{
    public Dictionary<string, AudioClip> NowPlayAudioDic;
    private AudioSource NowPlayingAudio;
    private bool _testButton;

    /// <summary>
    /// 是否下载完
    /// </summary>
    public bool LoadOverFlag { get; set; }
    public void Awake()
    {
        NowPlayingAudio = GetComponent<AudioSource>();
        NowPlayAudioDic = new Dictionary<string, AudioClip>();
    }

    public void Start()
    {
        OnGUIManager.Instance.OnGuiAction += OnGUIAudioManager;
        StudyManager.Instance.OnEndStudy += Reset;
    }


    /// <summary>
    /// 根据名字播放相应音频
    /// </summary>
    /// <param name="AudioName"></param>
    public void PlayAudio(string AudioName)
    {
        if (StudyManager.Instance.CurrentStep.PlayMode == PlayMode.Continue)
        {
            return;
        }
        if (NowPlayingAudio != null)
            if (NowPlayingAudio.isPlaying)
                NowPlayingAudio.Stop();
        AudioClip tempAudioClip;
        if (NowPlayAudioDic.TryGetValue(AudioName, out tempAudioClip))
        {
            NowPlayingAudio.clip = tempAudioClip;
        }
        NowPlayingAudio.Play();
    }

    public void StopPlay()
    {
        NowPlayingAudio.Stop();
    }

    public void OnGUIAudioManager()
    {
        if (GUILayout.Button("__Audio"))
        {
            _testButton = !_testButton;
        }
        if (_testButton)
        {
            if (GUILayout.Button("测试添加音频Radar到字典"))
            {
                ReloadAudioToDic("radar");
            }
        }
    }
    /// <summary>
    /// 下载相应的音频
    /// </summary>
    /// <param name="name"></param>
    public void ReloadAudioToDic(string name)
    {
        LoadOverFlag = false;
        //清空字典
        NowPlayAudioDic.Clear();
        {
            StartCoroutine(WWWLoadManager.Instance.LoadSource(ConfigManager.Instance.ConfigDictionary["url"] + name + ".audiopackage", () =>
            {
                for (int i = 0; i < WWWLoadManager.Instance.www.assetBundle.LoadAllAssets().Length; i++)
                {
                    NowPlayAudioDic.Add(WWWLoadManager.Instance.www.assetBundle.LoadAllAssets()[i].name, WWWLoadManager.Instance.www.assetBundle.LoadAllAssets()[i] as AudioClip);
                }
                LoadOverFlag = true;
            }));
        }

    }

    public void Reset()
    {
        StopPlay();
    }
}
