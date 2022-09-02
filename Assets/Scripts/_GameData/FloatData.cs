using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;


namespace GameData
{
  public sealed class FloatData : Data<float>
  {
    protected override bool Equals(float value) => this.value == value;
    
    public FloatData() => callbacks = new List<Action<float>>();
  }

  public static partial class HelperGameDate
  {
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static FloatData GetFloatData(this string key) => key.Data<FloatData>();
  }
}




