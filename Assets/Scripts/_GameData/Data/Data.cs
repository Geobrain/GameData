using System;
using System.Collections.Generic;
using UnityEngine;


namespace GameData
{
  [Serializable]
  public abstract class Data<T> : IDisposable
  {
    public T value;
    protected List<Action<T>> callbacks;
    public virtual T Value
    {
      get => value;
      set
      {
        if (Equals(value)) return;
        foreach (var callback in callbacks) callback.Invoke(value);
        this.value = value;
      }
    }

    protected abstract bool Equals(T value);

    public void AddObserver(Action<T> callback)
    {
      callback.Invoke(Value); // send first value
      callbacks.Add(callback);
    }

    public virtual void Dispose()
    {
      callbacks = null;
    }
  }
}




