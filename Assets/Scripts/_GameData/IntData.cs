using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;


namespace GameData
{
  [Serializable]
  public sealed class IntData : Data<int>
  {
    public IntData() => callbacks = new List<Action<int>>();
    
    protected override bool Equals(int value) => this.value == value;
  }

  public static partial class GameDate
  {
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static IntData IntData(this string key) => key.Data<IntData>(); //unboxing!
  }
}




