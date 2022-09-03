using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;


namespace GameData
{
  public sealed class FloatData : Data<float>
  {
    public FloatData() => callbacks = new List<Action<float>>();
    
    protected override bool Equals(float value) => this.value == value;
  }

  public static partial class GameDate
  {
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static FloatData FloatData(this string key) => key.Data<FloatData>(); //unboxing!
  }
}




