using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;


namespace GameData
{
  [Serializable]
  public sealed class EventData : IDisposable
  {
    private List<Action> callbacks;
    
    public EventData() => callbacks = new List<Action>();

    public void AddObserver(Action callback) => callbacks.Add(callback);

    public void Invoke()
    {
      foreach (var callback in callbacks) callback.Invoke();
    }

    public void Dispose()
    {
      callbacks = null;
    }
  }

  public static partial class GameDate
  {
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static EventData EventData(this string key) => key.Data<EventData>(); //unboxing!
  }
}