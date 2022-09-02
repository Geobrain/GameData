using System;
using System.Collections;
using System.Collections.Generic;
using GameData;
using TMPro;
using UnityEngine;


public partial class DataKeys
{
  [FieldKey(categoryName = "GameData/Level")] public const string Float_LevelTime = "LevelTime";
}

public class FloatDataExampleManager: MonoBehaviour
{
  [KeyFilter(typeof(DataKeys))] public string key;
  public TextMeshProUGUI text;
  public GameObject prefab;
  private FloatData levelTime;

  private void OnEnable()
  {
    key.AddData<FloatData>();
  }

  private void OnDisable()
  {
    key.RemoveData();
  }

  private void Start()
  {
    levelTime = key.GetFloatData(); //data cash
    
    //AddObserver 
    key.Data<FloatData>().AddObserver(value =>
    {
      text.text = value.ToString("F2");
    });
  }

  void Update()
  {
    levelTime.Value += Time.deltaTime;

    if (levelTime.Value > 3f)
    {
      key.Data<FloatData>().Value = 0; //unboxing
      Instantiate(prefab);
    }
  }
}