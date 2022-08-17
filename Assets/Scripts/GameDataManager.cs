using System;
using System.Collections;
using System.Collections.Generic;
using GameData;
using UnityEngine;

public class GameDataManager : MonoBehaviour
{

}

public partial class DataKeys
{
  [FieldKey(categoryName = "GameData/Level")] public const string Float_LevelTime = "LevelTime";
}


public class SceneData
{
  [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSplashScreen)]
  internal static void SetGameData()
  {
    DataKeys.Float_LevelTime.AddData<FloatData>();
  }
}
