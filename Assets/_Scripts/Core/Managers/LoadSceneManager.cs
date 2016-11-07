using System;
using UnityEngine;
using System.Collections;
using Pan_Tools;
using UnityEngine.SceneManagement;

public class LoadSceneManager : MonoSingleton<LoadSceneManager>
{
    private AsyncOperation _modelScene;
    private AsyncOperation _UIScene;

    public bool LoadOver { get; set; }

    public Action OnLoadSceneOver;
    // Use this for initialization
    IEnumerator Start()
    {
        _UIScene = SceneManager.LoadSceneAsync("UI", LoadSceneMode.Additive);
        yield return _UIScene;
        _modelScene = SceneManager.LoadSceneAsync("Model", LoadSceneMode.Additive);
        yield return _modelScene;
        LoadOver = true;
        if (OnLoadSceneOver != null)
            OnLoadSceneOver();
    }
}
