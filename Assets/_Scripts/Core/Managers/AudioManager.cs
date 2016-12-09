using UnityEngine;
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
            if (NowPlayingAudio != null) NowPlayingAudio.clip = tempAudioClip;
        }
        //播放延迟
        if (NowPlayingAudio != null)
        {
            NowPlayingAudio.PlayDelayed(0.3f);
            NowPlayingAudio.Play();
        }
    }

    public void StopPlay()
    {
        NowPlayingAudio.Stop();
        NowPlayingAudio.clip = null;
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
        NowPlayAudioDic.Clear();
        if (!WWWLoadManager.Instance.Offline)
        {
            //清空字典
            {
                StartCoroutine(WWWLoadManager.Instance.LoadSource(ConfigManager.Instance.ConfigDictionary["url"] + ConfigManager.Instance.ConfigDictionary[name], () =>
                {
                    for (int i = 0; i < WWWLoadManager.Instance.Www.assetBundle.LoadAllAssets().Length; i++)
                    {
                        NowPlayAudioDic.Add(WWWLoadManager.Instance.Www.assetBundle.LoadAllAssets()[i].name, WWWLoadManager.Instance.Www.assetBundle.LoadAllAssets()[i] as AudioClip);
                    }
                    LoadOverFlag = true;
                }));
            }
        }
        else
        {
            var res = Resources.LoadAll<AudioClip>("audios/" + name);
            for (int i = 0; i < res.Length; i++)
            {
                NowPlayAudioDic.Add(res[i].name, res[i]);
            }
            LoadOverFlag = true;
        }
    }

    public void Reset()
    {
        StopPlay();
    }
}
