using System;
using UnityEngine;
using System.Collections;
using BestHTTP;
using Pan_Tools;

public class WWWLoadManager : MonoSingleton<WWWLoadManager>
{
    public WWW www;
    [Tooltip("是否离线下载")]
    public bool Offline;

    public string ConfigUrl = "";
    public void Start()
    {
        HTTPRequest request = new HTTPRequest(new Uri("ConfigUrl"), OnRequestFinished);
        request.Send();
    }
    void OnRequestFinished(HTTPRequest request, HTTPResponse response)
    {
        Debug.Log("Request Finished! Text received: " + response.DataAsText);
    }
    public IEnumerator LoadSource(string path, Action action = null)
    {
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
