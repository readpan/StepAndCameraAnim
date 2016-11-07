using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using BestHTTP;
using BestHTTP.Caching;
using Pan_Tools;
using UnityEngine.Analytics;

public class ConfigManager : MonoSingleton<ConfigManager>
{
    [Tooltip("配置文件的地址")]
    public string ConfigUrl = "";
    private bool _receiveConfigFlag;
    private HTTPRequest _request;
    public Dictionary<string, string> ConfigDictionary;

    private string accessStr;

    private void Awake()
    {
        ConfigDictionary = new Dictionary<string, string>();
    }

    public void Start()
    {
        LoadSceneManager.Instance.OnLoadSceneOver += () =>
        {
            StartCoroutine(StartLoadConfig());
        };
    }

    public IEnumerator StartLoadConfig()
    {
        yield return new WaitForSeconds(0.1f);
        HTTPCacheService.BeginClear();
        //程序开始时候,加载config配置文件
        _request = new HTTPRequest(new Uri(ConfigUrl), true, OnRequestFinished);
        _request.Send();


    }
    void OnRequestFinished(HTTPRequest req, HTTPResponse resp)
    {

        switch (req.State)
        {
            // The request finished without any problem.
            case HTTPRequestStates.Finished:
                Debug.Log("Request Finished! Text received: " + resp.DataAsText);
                if (resp.DataAsText.Contains("ENOENT"))
                {
                    MeditorManager.Instance.MeditorUi.SetAccess("Url Error.");
                    return;
                }
                SetReceiveConfigFlag(true);
                ConfigConfigDic(resp);
                if (ConfigDictionary.TryGetValue("access", out accessStr))
                {
                    //加载成功
                    if (accessStr == "true")
                    {
                        MeditorManager.Instance.MeditorUi.SetDownLoadReady();
                    }
                    else
                    {
                        MeditorManager.Instance.MeditorUi.SetAccess("access denied.");
                    }
                }
                else
                {
                    MeditorManager.Instance.MeditorUi.SetAccess("Not such a key \"access\"");
                }
                Debug.Log("Request Finished Successfully!\n" + resp.DataAsText);
                break;


            // The request finished with an unexpected error.
            // The request's Exception property may contain more information about the error.
            case HTTPRequestStates.Error:
                string errinfo = "Request Finished with Error! " +
                                 (req.Exception != null
                                     ? (req.Exception.Message + "\n" + req.Exception.StackTrace)
                                     : "No Exception");
                MeditorManager.Instance.MeditorUi.SetAccess(errinfo);
                Debug.LogError(errinfo);
                break;


            // The request aborted, initiated by the user.
            case HTTPRequestStates.Aborted:
                MeditorManager.Instance.MeditorUi.SetAccess("Request Aborted!");
                Debug.LogWarning("Request Aborted!");
                break;


            // Ceonnecting to the server timed out.
            case HTTPRequestStates.ConnectionTimedOut:
                MeditorManager.Instance.MeditorUi.SetAccess("Connection Timed Out!");
                Debug.LogError("Connection Timed Out!");
                break;
            // The request didn't finished in the given time.
            case HTTPRequestStates.TimedOut:
                Debug.LogError("Processing the request Timed Out!");
                break;
        }



    }
    /// <summary>
    /// 是否收到了config文件
    /// </summary>
    /// <returns></returns>
    public bool GetReceiveConfigFlag()
    {
        return _receiveConfigFlag;
    }

    public void SetReceiveConfigFlag(bool flag)
    {
        _receiveConfigFlag = flag;
    }

    private void ConfigConfigDic(HTTPResponse response)
    {
        string[] conStrings = response.DataAsText.Split('\n');
        for (int i = 0; i < conStrings.Length; i++)
        {
            string[] tempStr = conStrings[i].Split('=');
            ConfigDictionary.Add(tempStr[0].Trim(), tempStr[1].Trim());
        }
    }
}
