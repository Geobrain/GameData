using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;


namespace GameData
{
  [Serializable]
  public sealed class BoolData : Data<bool>
  {
    protected override bool Equals(bool value) => this.value == value;
    
    public BoolData() => callbacks = new List<Action<bool>>();
  }

  public static partial class HelperGameDate
  {
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static BoolData GetBoolData(this string key) => key.Data<BoolData>();
  }
}




