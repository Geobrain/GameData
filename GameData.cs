using System;
using System.Runtime.CompilerServices;
using Unity.IL2CPP.CompilerServices;


internal static partial class GameData
{
  internal static ArrayGameDates gameData = new ();
}


public sealed class ArrayGameDates
{
  public ObjectData[] array;
  public int length;

  public ref ObjectData this[int index]
  {
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    get => ref array[index];
  }

  public ArrayGameDates(int cap = 0)
  {
    array = new ObjectData[cap > 0 ? cap : 5];
    length = 0;
  }
  
  [Il2CppSetOption(Option.NullChecks | Option.ArrayBoundsChecks, false)]
  public void Add<T>(string key) where T : new()
  {
    if (length >= array.Length)
    {
      Array.Resize(ref array, length << 1);
    }
    array[length++] = new ObjectData(key, new T());
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


public static partial class DataHelper
{
  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  private static object Data(this string key)
  {
    for (var index = 0; index < GameData.gameData.array.Length; index++)
    {
      var data = GameData.gameData.array[index];
      if (data.Equals(key))
      {
        return data.obj;
      }
    }

    return null;
  }
}
