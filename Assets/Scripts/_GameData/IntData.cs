using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;


namespace GameData
{
  [Serializable]
  public sealed class IntData : Data<int>
  {
    protected override bool Equals(int value) => this.value == value;
    
    public IntData() => callbacks = new List<Action<int>>();
  }

  public static partial class HelperGameDate
  {
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static IntData GetIntData(this string key) => key.Data<IntData>();
  }
}




