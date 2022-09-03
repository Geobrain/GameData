using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace GameData
{
  public sealed class FloatData : Data<float>
  {
    protected override bool Equals(float value) => Value == value;
  }

  public static partial class GameDate
  {
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static FloatData FloatData(this string key) => key.Data<FloatData>(); //unboxing!
  }
}




