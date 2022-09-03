/*
using System;
using System.Runtime.CompilerServices;
using UnityEngine;


public sealed class ArrayGame<T>
{
  private CallbackData<T>[] source;
  public int Length;

  public ref CallbackData<T> this[int index]
  {
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    get => ref source[index];
  }

  public ArrayGame()
  {
    source = new CallbackData<T>[5];
    Length = 0;
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public void Add(in CallbackData<T> member)
  {
    if (Length >= source.Length)
      Array.Resize(ref source, Length << 1);

    source[Length++] = member;
  }
    
  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public bool Remove(Action<T> callback)
  {
    var index = -1;

    for (var i = 0; i < Length; i++)
    {
      ref CallbackData<T> val = ref source[i];	

      if (val.callback == callback)
      {
        index = i;
        break;
      }
    }

    var removed = index > -1;
    if (removed && index < --Length)
    {
      Array.Copy(source, index + 1, source, index, Length - index);
    }
      
#if UNITY_EDITOR
    Debug.LogWarning($"Remove value: \"{callback}\"! {Length}");
#endif
        
    return removed;
  }
}

[Serializable]
public class CallbackData<T>  : IEquatable<Action<T>>
{
  public object obj;
  public Action<T> callback;

  public CallbackData(object obj, Action<T> callback)
  {
    this.obj = obj;
    this.callback = callback;
  }

  public bool Equals(Action<T> callback) => this.callback == callback;
}
*/
