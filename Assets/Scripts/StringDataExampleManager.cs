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
    key.StringData().AddObserver(value =>
    {
      text.text = value;
    });
  }

  void Update()
  {
    levelTime += Time.deltaTime;
    key.StringData().Value = levelTime.ToString(); //warning unboxing!

    if (levelTime > 3)
    {
      levelTime = 0;
      key.StringData().Value = levelTime.ToString();
      Instantiate(prefab);
    }
    
    if (Input.GetKeyDown(KeyCode.A))
    {
      key.RemoveData();
    }
  }
}