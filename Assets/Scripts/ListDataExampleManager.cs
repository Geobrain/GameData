using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using GameData;
using TMPro;
using UnityEngine;


public partial class DataKeys
{
  [FieldKey(categoryName = "GameData/Level")] public const string ListFloat_LevelTime = "ListFloat_LevelTime";
}

public class ListDataExampleManager: MonoBehaviour
{
  [KeyFilter(typeof(DataKeys))] public string key;
  public TextMeshProUGUI text;
  public GameObject prefab;
  private ListData<float> levelTimes;

  private void OnEnable()
  {
    key.AddData<ListData<float>>();
  }

  private void OnDisable()
  {
    key.RemoveData();
  }

  private void Start()
  {
    levelTimes = key.GetListData<float>(); //data cache
    levelTimes.Value.Add(0);
    
    //AddObserver 
    levelTimes.AddObserver(value =>
    {
      text.text = value[0].ToString("F2");
    });
  }

  void Update()
  {
    levelTimes.Value[0] += Time.deltaTime;

    if (levelTimes.Value[0] > 3f)
    {
      levelTimes.Value[0] = 0; 
      Instantiate(prefab);
    }
  }
}