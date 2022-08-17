using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;


namespace GameData
{
  public static class GameDate
  {
    private static ArrayGameDates gameData = new ArrayGameDates();
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void AddData<T>(this string key) where T : new() => gameData.Add<T>(key);

    public static T Data<T>(this string key) => (T) key.Data();
    
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
      array = new ObjectData[50];
      Length = 0;
    }

    public void Add<T>(string key) where T : new()
    {
      if (Length >= array.Length)
      {
        Array.Resize(ref array, Length << 1);
      }

      array[Length++] = new ObjectData(key, new T());
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