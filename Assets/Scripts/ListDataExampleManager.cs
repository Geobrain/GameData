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
    key.ListData<float>().Value.Add(0);
    
    key.ListData<float>().AddObserver(this, value =>
    {
      text.text = value[0].ToString("F2");
    });
  }

  void Update()
  {
    key.ListData<float>().Value[0] += Time.deltaTime; //warning unboxing!

    if (key.ListData<float>().Value[0] > 3f)
    {
      key.ListData<float>().Value[0] = 0; 
      Instantiate(prefab);
    }
    
    if (Input.GetKeyDown(KeyCode.A))
    {
      key.RemoveData();
    }
  }
}