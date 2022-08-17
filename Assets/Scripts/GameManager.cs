using System.Collections;
using System.Collections.Generic;
using GameData;
using UnityEngine;


public class GameManager: MonoBehaviour
{
  public GameObject prefab;
  private float time;

  void Update()
  {
    DataKeys.Float_LevelTime.Data<FloatData>().Value += Time.deltaTime;

    if (DataKeys.Float_LevelTime.Data<FloatData>().Value > 3f)
    {
      DataKeys.Float_LevelTime.Data<FloatData>().Value = 0;
      Instantiate(prefab);
    }
  }
}