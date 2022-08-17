using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;


namespace GameData
{
  [Serializable]
  public sealed class ListData<T> // and string type
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

}