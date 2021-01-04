using Magnum.Collections;
using System;
using System.Collections.Generic;

public class FirstLastList<T> : IFirstLastList<T> where T : IComparable<T>
{
    private List<T> byInsertion;
    private OrderedBag<T> byOrder;
    private OrderedBag<T> byOrderReversed;
    public FirstLastList()
    {
        byInsertion = new List<T>();
        byOrder = new OrderedBag<T>();
        byOrderReversed = new OrderedBag<T>((x,y)=> - x.CompareTo(y));
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
        byOrderReversed.Add(element);
    }

    public void Clear()
    {
        byInsertion.Clear();
        byOrder.Clear();
        byOrderReversed.Clear();
    }

    public IEnumerable<T> First(int count)
    {
        ValidateCount(count);
        for (int i = 0; i < count; i++)
        {
            yield return byInsertion[i];
        }
    }

    public IEnumerable<T> Last(int count)
    {
        ValidateCount(count);
        for (int i = byInsertion.Count - 1; i >= byInsertion.Count - count; i--)
        {
            yield return byInsertion[i];
        }
    }

    public IEnumerable<T> Max(int count)
    {
        ValidateCount(count);
        foreach (var item in byOrderReversed)
        {
            if (count <= 0)
            {
                break;
            }
            yield return item;
            count--;
        }
    }

    public IEnumerable<T> Min(int count)
    {
        ValidateCount(count);
        foreach (var item in byOrder)
        {
            if (count <= 0)
            {
                break;
            }
            yield return item;
            count--;
        }
    }

    private void ValidateCount(int count)
    {
        if (count < 0 || count > byOrder.Count)
        {
            throw new ArgumentOutOfRangeException("Not correct count of elements");
        }
    }

    public int RemoveAll(T element)
    {
        foreach (var item in byOrder.Range(element, true, element, true))
        {
            byInsertion.Remove(item);
        }
        var count = byOrder.RemoveAllCopies(element);
        byOrderReversed.RemoveAllCopies(element);

        return count;
    }
}
