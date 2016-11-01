using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameObjectInfoManager : MonoBehaviour
{

    private static GameObjectInfoManager _instance;

    public static GameObjectInfoManager Instance
    {

        get
        {
            if (_instance == null)
                _instance = FindObjectOfType<GameObjectInfoManager>();
            //todo 可以新建一个物体
            if (_instance == null)
            {
                Debug.LogError("Can't Find GameObject with GameObjectInfoManager component.");
                return null;
            }
            return _instance;
        }
    }

    private GameObjectInfo[] _gameObjectInfos;

    /// <summary>
    /// 所有物体的字典
    /// </summary>
    public Dictionary<int, GameObjectInfo> GameObjectInfosDic;

    public Action OnResetAction;

    public void Awake()
    {
        BuildGameObjectsInfoDictionary();
    }

    /// <summary>
    /// 添加场景中所有物体
    /// </summary>
    private void BuildGameObjectsInfoDictionary()
    {
        _gameObjectInfos = GetComponentsInChildren<GameObjectInfo>();
        GameObjectInfosDic = new Dictionary<int, GameObjectInfo>();
        for (int i = 0; i < _gameObjectInfos.Length; i++)
        {
            GameObjectInfosDic.Add(_gameObjectInfos[i].UniqueId, _gameObjectInfos[i]);
        }
    }

    public void AddGameObjectInfoDictionary(GameObjectInfo gameObjectInfo)
    {
        if (!GameObjectInfosDic.ContainsKey(gameObjectInfo.UniqueId))
        {
            _gameObjectInfos = gameObjectInfo.GetComponentsInChildren<GameObjectInfo>();
            for (int i = 0; i < _gameObjectInfos.Length; i++)
            {
                try
                {
                    GameObjectInfosDic.Add(_gameObjectInfos[i].UniqueId, _gameObjectInfos[i]);
                }
                catch (Exception)
                {
                    Debug.LogError("There is already a key" + _gameObjectInfos[i].UniqueId + ". Please check.");
                }
            }
        }
    }
}
