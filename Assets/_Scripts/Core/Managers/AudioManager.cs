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
        //Debug.Log(WWW.LoadFromCacheOrDownload("file:///D:/test.JPG",0).size);
        //if (WWWLoadManager.Instance.Offline)
        //{
        //    for (int i = 0; i < 14; i++)
        //    {
        //        var tempAudioClip = Resources.Load(name + "/RadarRadar_Startup_" + string.Format("0:000", i)) as AudioClip;
        //        if (tempAudioClip != null) NowPlayAudioDic.Add(tempAudioClip.name, tempAudioClip);
        //    }
        //    var tempAudioClip1 = Resources.Load(name + "/Radar_Startup_FaSheJiXiang") as AudioClip;
        //    if (tempAudioClip1 != null) NowPlayAudioDic.Add(tempAudioClip1.name, tempAudioClip1);
        //    var tempAudioClip2 = Resources.Load(name + "/Radar_Startup_PeiDianXiang") as AudioClip;
        //    if (tempAudioClip2 != null) NowPlayAudioDic.Add(tempAudioClip2.name, tempAudioClip2);
        //    var tempAudioClip3 = Resources.Load(name + "/Radar_Startup_RDAJiGui") as AudioClip;
        //    if (tempAudioClip3 != null) NowPlayAudioDic.Add(tempAudioClip3.name, tempAudioClip3);
        //}
        //else
        {
            StartCoroutine(WWWLoadManager.Instance.LoadSource("http://oby0sn38x.bkt.clouddn.com/" + name + ".audiopackage", () =>
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
