using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using BestHTTP;
using Pan_Tools;

public class WWWLoadManager : MonoSingleton<WWWLoadManager>
{
    public WWW Www;
    [Tooltip("是否离线下载")]
    public bool Offline;


    public IEnumerator LoadSource(string path, Action action = null)
    {
        yield return new WaitUntil(ConfigManager.Instance.GetReceiveConfigFlag);
        //卸载掉之前的资源
        if (Www != null)
            Www.assetBundle.Unload(true);

        Www = WWW.LoadFromCacheOrDownload(path, 1);
        yield return Www;
        Debug.Log("Loaded + size: " + Www.assetBundle.LoadAllAssets().Length);
        if (action != null)
            action();
    }

}
