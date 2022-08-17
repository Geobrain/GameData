using System;
using System.Collections;
using System.Collections.Generic;
using GameData;
using TMPro;
using UnityEngine;

public class GameUIController : MonoBehaviour
{
  public TextMeshProUGUI text;

  private void Awake()
  {
    DataKeys.Float_LevelTime.Data<FloatData>().AddObserver(value =>
    {
      text.text = value.ToString("F2");
    });
  }
}