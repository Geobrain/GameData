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
    key.IntData().AddObserver(this, value =>
    {
      text.text = value.ToString();
    });
  }

  void Update()
  {
    levelTime += Time.deltaTime;
    key.IntData().Value = (int) levelTime; //warning unboxing!

    if (key.IntData().Value == 3)
    {
      levelTime = 0;
      key.IntData().Value = 0; 
      Instantiate(prefab);
    }
    
    if (Input.GetKeyDown(KeyCode.A))
    {
      key.RemoveData();
    }
  }
}