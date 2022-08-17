using System;
using System.Collections.Generic;


namespace GameData
{
  [Serializable]
  public sealed class EventData
  {
    private List<Action> callbacks;

    public EventData() => callbacks = new List<Action>();

    public void AddEventObserver(Action callback) => callbacks.Add(callback);

    public void Invoke()
    {
      foreach (var callback in callbacks) callback.Invoke();
    }
  }
}