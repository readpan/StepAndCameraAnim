using System;
using UnityEngine;
using System.Collections;
using Pan_Tools;

public class WWWLoadManager : MonoSingleton<WWWLoadManager>
{
    public WWW www;
    public IEnumerator LoadSource(string path, Action action = null)
    {
        //卸载掉之前的资源
        if(www!=null)
            www.assetBundle.Unload(true);
        Debug.Log("Loading");
         www = WWW.LoadFromCacheOrDownload(path, 1);
        yield return www;
        Debug.Log("Loaded + size: " + www.assetBundle.LoadAllAssets().Length);
        if (action != null)
            action();
    }
}
