using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;


namespace GameData
{
  [Serializable]
  public sealed class EventData : IDisposable
  {
    private List<CallbackEvent<Object>> callbacks = new List<CallbackEvent<Object>>();
    public void AddObserver(Object subscriber, Action callback)
    {
      callbacks.Add(new CallbackEvent<Object>(subscriber, callback));
    }

    public void Invoke()
    {
      for (var i = callbacks.Count - 1; i >= 0; i--)
      {
        if (callbacks[i].subscriber != null)
        {
          callbacks[i].callback.Invoke();
        }
        else
        {
          callbacks.Remove(callbacks[i]);
        }
      }
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
  
  [Serializable]
  public class CallbackEvent<TObject>
  { 
    public TObject subscriber;
    public Action callback;

    public CallbackEvent(TObject subscriber, Action callback)
    {
      this.subscriber = subscriber;
      this.callback = callback;
    }
  }
}