using System;
using System.Collections;
using System.Collections.Generic;
using GameData;
using UnityEngine;


public partial class DataKeys
{
  [FieldKey(categoryName = "GameData/Level")] public const string Float_LevelTime = "Float_LevelTime";
}

public class FloatDataExampleManager: MonoBehaviour
{
  [KeyFilter(typeof(DataKeys))] public string key;
  public GameObject prefab;
  public GameObject prefabUI; 

  private void OnEnable()
  {
    key.AddData<FloatData>();
  }

  private void OnDisable()
  {
    key.RemoveData();
  }

  void Update()
  {
    key.FloatData().Value += Time.deltaTime; //warning unboxing!

    if (key.FloatData().Value > 3f)
    {
      key.FloatData().Value = 0; 
      Instantiate(prefab);
    }
    
    if (Input.GetKeyDown(KeyCode.A))
    {
      key.RemoveData();
    }
    
    if (Input.GetKeyDown(KeyCode.Q))
    {
      GameObject.Destroy(prefabUI);
    }
  }
}