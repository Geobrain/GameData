using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;


namespace GameData
{
  [Serializable]
  public sealed class StringData : Data<string>
  {
    protected override bool Equals(string value) => this.value == value;
  }
  
  public static partial class GameDate
  {
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static StringData StringData(this string key) => key.Data<StringData>(); //unboxing!
  }
}




