﻿using UnityEngine;
using System.Collections;
using Pan_Tools;
using UnityEngine.SceneManagement;

public class LoadSceneManager : MonoSingleton<LoadSceneManager>
{
    private AsyncOperation asyncOperation;
    // Use this for initialization
    void Start()
    {
        SceneManager.LoadSceneAsync("UI", LoadSceneMode.Additive);
        asyncOperation =   SceneManager.LoadSceneAsync("Model",LoadSceneMode.Additive);
    }

    // Update is called once per frame
    void Update()
    {
    }
}