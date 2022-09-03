using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;


namespace GameData
{
  [Serializable]
  public sealed class BoolData : Data<bool>
  {
    protected override bool Equals(bool value) => Value == value;
  }

  public static partial class GameDate
  {
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static BoolData BoolData(this string key) => key.Data<BoolData>(); //unboxing!
  }
}




