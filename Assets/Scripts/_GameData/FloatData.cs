using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;


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

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public FloatData() => callbacks = new List<Action<float>>();

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void AddObserver(Action<float> callback) => callbacks.Add(callback);
  }

  public static partial class HelperGameDate
  {
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static FloatData GetFloatData(this string key) => key.Data<FloatData>();
  }
}




