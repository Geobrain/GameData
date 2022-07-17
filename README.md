# Universal date for game entities
To exchange data between objects in a game session. Separate logic and don't use channels

## How to use
Add new date 
```csharp
[Serializable]
public sealed class FloatData
{
  public float value;
}


public static partial class GameDataHelper
{
  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static FloatData FloatData(this string key) => (FloatData) key.Data();
}
```

Add new key for date

```csharp
public static partial class GameDataKey
{
  public static readonly string LevelTime = "LevelTime";
}

public static partial class GameData
{
  [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSplashScreen)]
  internal static void SetLevelTime()
  {
    GameDate.gameData.Add<FloatData>(GameDataKey.LevelTime);
  }
}
```

Use it in your project!
```csharp
GameDataKey.LevelTime.FloatData().value = 600f;
```

## Code template:
```csharp
using System;
using System.Runtime.CompilerServices;
using UnityEngine;
using AppData;


public static partial class GameDataKey
{
  public static readonly string ${Key} = "${Key}";
}

public static partial class GameData
{
  [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSplashScreen)]
  internal static void Set${Key}()
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
