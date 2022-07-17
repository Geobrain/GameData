Template

using System;
using System.Runtime.CompilerServices;
using UnityEngine;


public partial class GameDataKey
{
  public static readonly string ${Key} = "${Key}";
}

internal static partial class GameData
{
  [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSplashScreen)]
  static void Setup()
  {
    gameData.Add<${Object_Type}>("${Key}");
  }
}


[Serializable]
public sealed class ${Object_Type}
{
  public ${Value_Type} value;
}


public static partial class DataHelper
{
  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static ${Object_Type} Get${Object_Type}(this string key) => (${Object_Type}) key.Data();
}
