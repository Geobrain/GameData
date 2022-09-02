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
    
    protected override bool Equals(ObservableCollection<T> value) => this.value == value;
    
    public ListData()
    {
      callbacks = new List<Action<ObservableCollection<T>>>();
      value = new ObservableCollection<T>();
      value.CollectionChanged += HandleChange;
    }
    
    private void HandleChange(object sender, NotifyCollectionChangedEventArgs notifyCollectionChangedEventArgs)
    {
      foreach (var callback in callbacks) callback.Invoke(Value);
    }  
  }
  
  public static partial class HelperGameDate
  {
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ListData<T> GetListData<T>(this string key) => key.Data<ListData<T>>();
  }
}