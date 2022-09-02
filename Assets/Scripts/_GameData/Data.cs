using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;


namespace GameData
{
  [Serializable]
  public abstract class Data<T>
  {
    protected T value;
    protected List<Action<T>> callbacks;
    public T Value
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
  }
}




