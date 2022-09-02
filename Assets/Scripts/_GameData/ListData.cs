using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Runtime.CompilerServices;


namespace GameData
{
  [Serializable]
  public sealed class ListData<T> 
  {
    private List<Action<ObservableCollection<T>>> callbacks;
    private ObservableCollection<T> value;
    public ObservableCollection<T> Value => value;

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
    
    public void AddObserver(Action<ObservableCollection<T>> callback) => callbacks.Add(callback);
  }
  
  public static partial class HelperGameDate
  {
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ListData<T> GetListData<T>(this string key) => key.Data<ListData<T>>();
  }
}