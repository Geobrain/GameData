using System;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;


namespace GameData
{
  [Serializable]
  public abstract class Data<T> : IDisposable
  {
    protected List<Callback<Object, T>> callbacks = new List<Callback<Object, T>>();
    protected T value;

    public virtual T Value
    {
      get => value;
      set
      {
        if (Equals(value)) return;
        SetCallback(value);
        this.value = value;
      }
    }

    protected void SetCallback(T value)
    {
      for (var i = callbacks.Count - 1; i >= 0; i--)
      {
        if (callbacks[i].subscriber != null)
        {
          callbacks[i].callback.Invoke(value);
        }
        else
        {
          callbacks.Remove(callbacks[i]);
        }
      }
    }

    protected abstract bool Equals(T value);

    public void AddObserver(Object subscriber, Action<T> callback)
    {
      callback.Invoke(Value); // send first value
      callbacks.Add(new Callback<Object, T>(subscriber, callback));
    }

    public virtual void Dispose()
    {
      callbacks = null;
    }
  }
  
  
  [Serializable]
  public class Callback<TObject, T>
  {
    public TObject subscriber;
    public Action<T> callback;

    public Callback(TObject subscriber, Action<T> callback)
    {
      this.subscriber = subscriber;
      this.callback = callback;
    }
  }
}




