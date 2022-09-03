using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;


[Serializable]
public class arr<T> : IEnumerable where T : IEquatable<T>
{
  public T[] source;
  public int length;

  public ref T this[int index]
  {
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    get => ref source[index];
  }

  public arr(int cap = 0)
  {
    source = new T[cap > 0 ? cap : 5];
    length = 0;
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public bool Has(in T member)
  {
    for (var i = 0; i < length; i++)
    {
      ref var val = ref source[i];
      if (member.Equals(val))
        return true;
    }

    return false;
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public void Add(in T member)
  {
    if (length >= source.Length)
      Array.Resize(ref source, length << 1);

    source[length++] = member;
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public bool Remove(in T member)
  {
    var index = -1;

    for (var i = 0; i < length; i++)
    {
      ref T val = ref source[i];
      // operator== is undefined for generic T; EqualityComparer solves this
      if (member.Equals(val))
      {
        index = i;
        break;
      }
    }

    var removed = index > -1;
    if (removed && index < --length)
      Array.Copy(source, index + 1, source, index, length - index);
    return removed;
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public List<T> ToList()
  {
    List<T> listT = new List<T>();
    for (var i = 0; i < length; i++)
    {
      ref T val = ref source[i];
      listT.Add(val);
    }

    return listT;
  }


  #region ENUMERATOR

  public Enumerator GetEnumerator()
  {
    return new Enumerator(this);
  }

  IEnumerator IEnumerable.GetEnumerator()
  {
    return GetEnumerator();
  }

  public struct Enumerator : IEnumerator<T>
  {
    arr<T> g;
    int position;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal Enumerator(arr<T> g)
    {
      position = g.length;
      this.g = g;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool MoveNext()
    {
      return --position >= 0;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Reset()
    {
      position = g.length;
    }

    object IEnumerator.Current => Current;

    public T Current
    {
      [MethodImpl(MethodImplOptions.AggressiveInlining)]
      get => g.source[position];
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Dispose()
    {
      g = null;
    }
  }

  #endregion
}