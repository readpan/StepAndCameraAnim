using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[ExecuteInEditMode]
public class FindGameObjectInfo : MonoBehaviour
{

    public int GameObjectInfoToFind = 0;
    public GameObjectInfo FindedGameObjectInfo;
    private GameObjectInfo[] _gameObjectInfos;
    public Dictionary<int, GameObjectInfo> GameObjectInfosDic;

    public void Awake()
    {
        BuildGameObjectsInfoDictionary();
    }
    // Use this for initialization
    void Start()
    {

    }
    private void BuildGameObjectsInfoDictionary()
    {
        _gameObjectInfos = GetComponentsInChildren<GameObjectInfo>();
        GameObjectInfosDic = new Dictionary<int, GameObjectInfo>();
        for (int i = 0; i < _gameObjectInfos.Length; i++)
        {
            GameObjectInfosDic.Add(_gameObjectInfos[i].UniqueId, _gameObjectInfos[i]);
        }
    }
    // Update is called once per frame
    void Update()
    {
        FindByGameObjectInfo();

    }

    [ContextMenu("Find")]
    public void FindByGameObjectInfo()
    {
        FindedGameObjectInfo = GameObjectInfosDic[GameObjectInfoToFind];
    }
}
