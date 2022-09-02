using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;


namespace GameData
{
  [Serializable]
  public sealed class BoolData
  {
    private List<Action<bool>> callbacks;
    private bool value;
    public bool Value
    {
      get => value;
      set
      {
        if (value == this.value) return;
        foreach (var callback in callbacks) callback.Invoke(value);
        this.value = value;
      }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public BoolData() => callbacks = new List<Action<bool>>();

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void AddObserver(Action<bool> callback)
    {
      callback.Invoke(Value); // send first value
      callbacks.Add(callback);
    }
  }

  public static partial class HelperGameDate
  {
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static BoolData GetBoolData(this string key) => key.Data<BoolData>();
  }
}




