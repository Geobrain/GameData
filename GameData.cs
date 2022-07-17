using System;
using System.Runtime.CompilerServices;
using Unity.IL2CPP.CompilerServices;


namespace AppData
{
  public static class GameDate
  {
    public static ArrayGameDates gameData = new();
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static object Data(this string key)
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

    [Il2CppSetOption(Option.NullChecks | Option.ArrayBoundsChecks, false)]
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
