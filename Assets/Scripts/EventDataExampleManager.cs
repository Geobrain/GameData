using System;
using System.Collections;
using System.Collections.Generic;
using GameData;
using TMPro;
using UnityEngine;


public partial class DataKeys
{
  [FieldKey(categoryName = "GameData/Level")] public const string Event_LevelTime = "Event_LevelTime";
}

public class EventDataExampleManager: MonoBehaviour
{
  [KeyFilter(typeof(DataKeys))] public string key;
  public TextMeshProUGUI text;
  public GameObject prefab;
  private float levelTime;

  private void OnEnable()
  {
    key.AddData<EventData>();
  }

  private void OnDisable()
  {
    key.RemoveData();
  }

  private void Start()
  {
    text.text = "";
    levelTime = 0;
    //AddObserver 
    key.Data<EventData>().AddObserver(() =>
    {
      text.text = "Event!";
    });
  }

  void Update()
  {
    if (levelTime > 2f && levelTime < 3f) //you can't write code like that))
    {
      text.text = "";
    }

    levelTime += Time.deltaTime;

    if (levelTime > 4f)
    {
      levelTime = 0;
      key.Data<EventData>().Invoke(); //unboxing
      Instantiate(prefab);
    }
  }
}