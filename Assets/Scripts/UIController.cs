﻿using System.Collections;
using System.Collections.Generic;
using GameData;
using TMPro;
using UnityEngine;

public class UIController : MonoBehaviour
{
  [KeyFilter(typeof(DataKeys))] public string key;
  public TextMeshProUGUI text;
  
  private void Start()
  {
    /*key.FloatData().AddObserver2(this, value =>
    {
      text.text = value.ToString("F2");
    });*/
    
    key.FloatData().AddObserver3(this, value =>
    {
      text.text = value.ToString("F2");
    });
  }
}