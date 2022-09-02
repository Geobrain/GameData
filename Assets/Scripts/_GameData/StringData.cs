using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;


namespace GameData
{
  [Serializable]
  public sealed class StringData : Data<string>
  {
    protected override bool Equals(string value) => this.value == value;
    
    public StringData() => callbacks = new List<Action<string>>();
  }
  
  public static partial class HelperGameDate
  {
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static StringData GetStringData(this string key) => key.Data<StringData>();
  }
}




