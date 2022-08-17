using System;
using System.Collections.Generic;


namespace GameData
{
  [Serializable]
  public sealed class FloatData
  {
    private List<Action<float>> callbacks;
    private float value;
    public float Value
    {
      get => value;
      set
      {
         this.value = value;
         foreach (var callback in callbacks) callback.Invoke(value);
      }
    }

    public FloatData() => callbacks = new List<Action<float>>();

    public void AddObserver(Action<float> callback) => callbacks.Add(callback);
  }

}




