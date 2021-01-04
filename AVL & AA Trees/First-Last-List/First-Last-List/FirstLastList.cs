using Magnum.Collections;
using System;
using System.Collections.Generic;
using System.Linq;

public class FirstLastList<T> : IFirstLastList<T> where T : IComparable<T>
{
    private LinkedList<T> byInsertion;
    private OrderedBag<LinkedListNode<T>> byOrder;
    private OrderedBag<LinkedListNode<T>> byOrderReversed;
    public FirstLastList()
    {
        byInsertion = new LinkedList<T>();
        byOrder = new OrderedBag<LinkedListNode<T>>((x, y) => x.Value.CompareTo(y.Value));
        byOrderReversed = new OrderedBag<LinkedListNode<T>>((x, y) => -x.Value.CompareTo(y.Value));
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
        var node = new LinkedListNode<T>(element);
        byInsertion.AddLast(element);
        byOrder.Add(node);
        byOrderReversed.Add(node);
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
        var current = byInsertion.First;
        while (count > 0)
        {
            yield return current.Value;
            current = current.Next;
            count--;
        }

        //return byInsertion.Take(count);

    }

    public IEnumerable<T> Last(int count)
    {
        ValidateCount(count);
        var current = byInsertion.Last;
        while (count > 0)
        {
            yield return current.Value;
            current = current.Previous;
            count--;
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
            yield return item.Value;
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
            yield return item.Value;
            count--;
        }
    }

    private void ValidateCount(int count)
    {
        if (count < 0 || count > byInsertion.Count)
        {
            throw new ArgumentOutOfRangeException("Not correct count of elements");
        }
    }

    public int RemoveAll(T element)
    {
        var node = new LinkedListNode<T>(element);
        var range = byOrder.Range(node, true, node, true);
        foreach (var item in range)
        {
            byInsertion.Remove(item.Value);
        }
        var count = byOrder.RemoveAllCopies(node);
        byOrderReversed.RemoveAllCopies(node);

        return count;
    }
}
