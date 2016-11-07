using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using BestHTTP;
using Pan_Tools;

public class WWWLoadManager : MonoSingleton<WWWLoadManager>
{
    public WWW www;
    [Tooltip("是否离线下载")]
    public bool Offline;


    public IEnumerator LoadSource(string path, Action action = null)
    {
        yield return new WaitUntil(ConfigManager.Instance.GetReceiveConfigFlag);
        //卸载掉之前的资源
        if (www != null)
            www.assetBundle.Unload(true);

        www = WWW.LoadFromCacheOrDownload(path, 1);
        yield return www;
        Debug.Log("Loaded + size: " + www.assetBundle.LoadAllAssets().Length);
        if (action != null)
            action();
    }

}
