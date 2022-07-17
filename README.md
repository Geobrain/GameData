# GameData
Separate the logic!

## How to use
Add new date 
```csharp
[Serializable]
public sealed class FloatData
{
  public float value;
}


public static partial class DataHelper
{
  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static FloatData FloatData(this string key) => (FloatData) key.Data();
}
```

Add new key for date

```csharp
public partial class GameDataKey
{
  public static readonly string LEVEL_TIME = "LEVEL_TIME";
}

internal static partial class GameData
{
  [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSplashScreen)]
  static void SetFloatData()
  {
    GameDate.gameData.Add<FloatData>(GameDataKey.LEVEL_TIME);
  }
}
```

Use it in your project!
```csharp
GameDataKey.LEVEL_TIME.FloatData().value = 600f;
```

## Template
```csharp
using System;
using System.Runtime.CompilerServices;
using UnityEngine;
using AppData;


public partial class GameDataKey
{
  public static readonly string ${Key} = "${Key}";
}

internal static partial class GameData
{
  [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSplashScreen)]
  static void Set${Date_Type}()
  {
    GameDate.gameData.Add<${Date_Type}>("${Key}");
  }
}


[Serializable]
public sealed class ${Date_Type}
{
  public ${Value_Type} value;
}


public static partial class DataHelper
{
  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static ${Date_Type} ${Date_Type}(this string key) => (${Date_Type}) key.Data();
}
```
