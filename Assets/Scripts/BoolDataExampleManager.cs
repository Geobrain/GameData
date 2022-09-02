using System;
using System.Collections;
using System.Collections.Generic;
using GameData;
using TMPro;
using UnityEngine;


public partial class DataKeys
{
  [FieldKey(categoryName = "GameData/Level")] public const string Bool_LevelTime = "Bool_LevelTime";
}

public class BoolDataExampleManager: MonoBehaviour
{
  [KeyFilter(typeof(DataKeys))] public string key;
  public TextMeshProUGUI text;
  public GameObject prefab;
  private float levelTime;
  private BoolData boolData;

  private void OnEnable()
  {
    key.AddData<BoolData>();
  }

  private void OnDisable()
  {
    key.RemoveData();
  }

  private void Start()
  {
    text.text = "";
    levelTime = 0;
    boolData = key.GetBoolData(); //data cache
      
    //AddObserver 
    boolData.AddObserver(value =>
    {
      text.text = $"{value}";
    });
  }

  void Update()
  {
    if (levelTime > 2f && levelTime < 3f) //you can't write code like that))
    {
      boolData.Value = false;
    }

    levelTime += Time.deltaTime;

    if (levelTime > 4f)
    {
      levelTime = 0;
      boolData.Value = true;
      Instantiate(prefab);
    }
  }
}