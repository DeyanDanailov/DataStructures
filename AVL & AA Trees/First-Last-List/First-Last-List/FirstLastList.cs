using Magnum.Collections;
using System;
using System.Collections.Generic;

public class FirstLastList<T> : IFirstLastList<T> where T : IComparable<T>
{
    private List<T> byInsertion;
    private OrderedBag<T> byOrder;
    public FirstLastList()
    {
        byInsertion = new List<T>();
        byOrder = new OrderedBag<T>();
    }
    public int Count
    {
        get
        {
            return byInsertion.Count;
        }
    }

    public void Add(T element)
    {
        byInsertion.Add(element);
        byOrder.Add(element);
    }

    public void Clear()
    {
        byInsertion.Clear();
        byOrder.Clear();
    }

    public IEnumerable<T> First(int count)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<T> Last(int count)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<T> Max(int count)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<T> Min(int count)
    {
        throw new NotImplementedException();
    }

    public int RemoveAll(T element)
    {
        throw new NotImplementedException();
    }
}
