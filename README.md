# Universal date for game entities
To exchange data between objects in a game session. Separate game logic and don't use channels for ECS

## How to use
Add new date 
```csharp
  [Serializable]
  public sealed class FloatData
  {
    private List<Action<float>> callbacks;
    private float value;
    public float Value
    {
      get => value;
      set
      {
         this.value = value;
         foreach (var callback in callbacks) callback.Invoke(value);
      }
    }

    public FloatData() => callbacks = new List<Action<float>>();

    public void AddObserver(Action<float> callback) => callbacks.Add(callback);
  }
```

Add new key for date

```csharp
public partial class DataKeys
{
  [FieldKey(categoryName = "GameData/Level")] public const string Float_LevelTime = "LevelTime";
}


public class SceneData
{
  [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSplashScreen)]
  internal static void SetGameData()
  {
    DataKeys.Float_LevelTime.AddData<FloatData>();
  }
}

```

Use it in your project!
```csharp
DataKeys.Float_LevelTime.Data<FloatData>().Value = 1f;
```
add observer
```csharp
  private void Awake()
  {
    DataKeys.Float_LevelTime.Data<FloatData>().AddObserver(value =>
    {
      text.text = value.ToString("F2");
    });
  }
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
