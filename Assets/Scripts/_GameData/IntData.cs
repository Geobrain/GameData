using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;


namespace GameData
{
  [Serializable]
  public sealed class IntData
  {
    private List<Action<int>> callbacks;
    private int value;
    public int Value
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
    public IntData() => callbacks = new List<Action<int>>();

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void AddObserver(Action<int> callback) => callbacks.Add(callback);
  }

  public static partial class HelperGameDate
  {
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static IntData GetIntData(this string key) => key.Data<IntData>();
  }
}




