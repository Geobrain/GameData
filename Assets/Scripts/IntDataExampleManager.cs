using System;
using System.Collections;
using System.Collections.Generic;
using GameData;
using TMPro;
using UnityEngine;


public partial class DataKeys
{
  [FieldKey(categoryName = "GameData/Level")] public const string Int_LevelTime = "Int_LevelTime";
}

public class IntDataExampleManager: MonoBehaviour
{
  [KeyFilter(typeof(DataKeys))] public string key;
  public TextMeshProUGUI text;
  public GameObject prefab;
  private IntData intData;
  private float levelTime;

  private void OnEnable()
  {
    key.AddData<IntData>();
  }

  private void OnDisable()
  {
    key.RemoveData();
  }

  private void Start()
  {
    intData = key.GetIntData(); //data cache
    
    //AddObserver 
    intData.AddObserver(value =>
    {
      text.text = value.ToString();
    });
  }

  void Update()
  {
    levelTime += Time.deltaTime;
    intData.Value = (int) levelTime;

    if (intData.Value == 3)
    {
      levelTime = 0;
      intData.Value = 0; 
      Instantiate(prefab);
    }
  }
}