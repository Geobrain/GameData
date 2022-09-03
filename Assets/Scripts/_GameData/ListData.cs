using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Runtime.CompilerServices;


namespace GameData
{
  [Serializable]
  public sealed class ListData<T> : Data<ObservableCollection<T>>
  {
    public override ObservableCollection<T> Value => value;  
    
    public ListData()
    {
      callbacks = new List<Action<ObservableCollection<T>>>();
      value = new ObservableCollection<T>();
      value.CollectionChanged += HandleChange;
    }  
    
    public override void Dispose()
    {
      callbacks = null;
      value.CollectionChanged -= HandleChange;
      value = null;
    }     
    
    protected override bool Equals(ObservableCollection<T> value) => this.value == value; //not used

    private void HandleChange(object sender, NotifyCollectionChangedEventArgs notifyCollectionChangedEventArgs)
    {
      foreach (var callback in callbacks) callback.Invoke(Value);
    }
  }
  
  public static partial class GameDate
  {
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ListData<T> ListData<T>(this string key) => key.Data<ListData<T>>(); //unboxing!
  }
}