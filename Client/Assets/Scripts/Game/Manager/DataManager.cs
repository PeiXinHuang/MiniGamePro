using System;
using System.Collections.Generic;
using UnityEngine;
public class DataManager : SingletonMonoBehaviour<DataManager>
{
    public List<LevelData> levelList;
    public List<GoodData> goodList;
    public override void Init()
    {
        base.Init();
        TextAsset levelAsset = Resources.Load<TextAsset>("Data/levelData");
        LevelDataWrap levelDataWrap = JsonUtility.FromJson<LevelDataWrap>(levelAsset.text);
        levelList = levelDataWrap.levelDatas;
      
        TextAsset goodAsset = Resources.Load<TextAsset>("Data/goodData");
        GoodDataWrap goodDataWrap = JsonUtility.FromJson<GoodDataWrap>(goodAsset.text);
        goodList = goodDataWrap.goodDatas;
    }
}