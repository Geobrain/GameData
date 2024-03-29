using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;


namespace GameData
{
  public static partial class GameDate
  {
    private static ArrayGameDates gameData = new ArrayGameDates();
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void AddData<T>(this string key) where T : new() => gameData.Add<T>(key);
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void RemoveData(this string key) => gameData.Remove(key);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static T Data<T>(this string key) => (T) key.Data();

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static object Data(this string key)
    {
      for (var index = 0; index < gameData.Length; index++)
      {
        var data = gameData[index];
        if (data.Equals(key))
        {
          return data.obj;
        }
      }

#if UNITY_EDITOR
      Debug.LogError($"No date with key \"{key}\"!");
#endif

      return null;
    }
  }

  public sealed class ArrayGameDates
  {
    private ObjectData[] array;
    public int Length;

    public ref ObjectData this[int index]
    {
      [MethodImpl(MethodImplOptions.AggressiveInlining)]
      get => ref array[index];
    }

    public ArrayGameDates()
    {
      array = new ObjectData[5];
      Length = 0;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Add<T>(string key) where T : new()
    {
      if (Length >= array.Length)
      {
        Array.Resize(ref array, Length << 1);
      }
      array[Length++] = new ObjectData(key, new T());
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool Remove(string key)
    {
      var index = -1;

      for (var i = 0; i < Length; i++)
      {
        ref ObjectData val = ref array[i];	

        if (val.key == key)
        {
          index = i;
          break;
        }
      }

      ((IDisposable) array[index].obj).Dispose();

      var removed = index > -1;
      if (removed && index < --Length)
      {
        Array.Copy(array, index + 1, array, index, Length - index);
      }
      
#if UNITY_EDITOR
      Debug.LogWarning($"Remove value: \"{key}\"! {Length}");
#endif
        
      return removed;
    }
  }


  [Serializable]
  public class ObjectData : IEquatable<string>
  {
    public string key;
    public object obj;

    public ObjectData(string key, object obj)
    {
      this.key = key;
      this.obj = obj;
    }

    public bool Equals(string key) => this.key == key;
  }
}