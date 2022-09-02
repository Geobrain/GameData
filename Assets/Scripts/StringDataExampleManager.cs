using System;
using System.Collections;
using System.Collections.Generic;
using GameData;
using TMPro;
using UnityEngine;


public partial class DataKeys
{
  [FieldKey(categoryName = "GameData/Level")] public const string String_LevelTime = "String_LevelTime";
}

public class StringDataExampleManager: MonoBehaviour
{
  [KeyFilter(typeof(DataKeys))] public string key;
  public TextMeshProUGUI text;
  public GameObject prefab;
  private StringData stringData;
  private float levelTime;

  private void OnEnable()
  {
    key.AddData<StringData>();
  }

  private void OnDisable()
  {
    key.RemoveData();
  }

  private void Start()
  {
    stringData = key.GetStringData(); //data cache
    
    //AddObserver 
    stringData.AddObserver(value =>
    {
      text.text = value;
    });
  }

  void Update()
  {
    levelTime += Time.deltaTime;
    stringData.Value = levelTime.ToString(); //you can't write code like that))

    if (levelTime > 3)
    {
      levelTime = 0;
      stringData.Value = levelTime.ToString();
      Instantiate(prefab);
    }
  }
}