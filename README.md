# Universal date for game entities
To exchange data between objects in a game session. Separate game logic and don't use channels.

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

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public FloatData() => callbacks = new List<Action<float>>();

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void AddObserver(Action<float> callback) => callbacks.Add(callback);
  }

  public static partial class HelperGameDate
  {
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static FloatData GetFloatData(this string key) => key.Data<FloatData>();
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
