using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using Object = UnityEngine.Object;


namespace GameData
{
  public sealed class FloatData : Data<float>
  {
    //public arr<CallbackData<float>> callbacks2;
    public List<CallbackData3<Object, float>> callbacks3;


    public override float Value
    {
      get => value;
      set
      {
        if (Equals(value)) return;

        for (int i = callbacks3.Count - 1; i >= 0; i--)
        {
          if (callbacks3[i].subscriber != null)
          {
            callbacks3[i].callback.Invoke(value);
          }
          else
          {
            callbacks3.Remove(callbacks3[i]);
          }
        }

        /*for (int i = 0; i < callbacks2.Count; i++)
        {
          if (callbacks2[i].tSource == null)
          {
            callbacks2.Remove(callbacks2[i]);
          }
        }*/
        
        Debug.Log($"!!!!!!!! длина массива {callbacks3.Count}!");
        Debug.Log($"!!!!!!!! колбек {callbacks3[0].callback}!");
        
        
        this.value = value;
      }
    }
    
    public FloatData()
    {
      callbacks = new List<Action<float>>();
      callbacks3 = new List<CallbackData3<Object, float>>();
    }

    protected override bool Equals(float value) => this.value == value;

    public void AddObserver3(Object subscriber, Action<float> callback)
    {
      callback.Invoke(Value); // send first value
      callbacks3.Add(new CallbackData3<Object, float>(subscriber, callback));
    }
  }

  public static partial class GameDate
  {
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static FloatData FloatData(this string key) => key.Data<FloatData>(); //unboxing!
  }
  
  [Serializable]
  public class CallbackData3<Object, T>
  {
    public Object subscriber;
    public Action<T> callback;

    public CallbackData3(Object subscriber, Action<T> callback)
    {
      this.subscriber = subscriber;
      this.callback = callback;
    }

    //public bool Equals(Action<T> other)  => this.callback == other.callback;
  }
}




