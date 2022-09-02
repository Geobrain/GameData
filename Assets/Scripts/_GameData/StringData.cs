using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;


namespace GameData
{
  [Serializable]
  public sealed class StringData
  {
    private List<Action<string>> callbacks;
    private string value;
    public string Value
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
    public StringData() => callbacks = new List<Action<string>>();

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void AddObserver(Action<string> callback) => callbacks.Add(callback);
  }

  public static partial class HelperGameDate
  {
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static StringData GetStringData(this string key) => key.Data<StringData>();
  }
}




