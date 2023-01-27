using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModsDudeServer.Domain.Helpers;
internal class ProtectedHashSet<T> : ISet<T>
{
    private readonly HashSet<T> _set;


    public ProtectedHashSet()
    {
        _set = new();
    }

    public ProtectedHashSet(IEnumerable<T> collection)
    {
        _set = new(collection);
    }


    public int Count => _set.Count;

    public bool IsReadOnly => false;

    public bool Add(T item)
    {
        return _set.Add(item);
    }

    public void Clear()
    {
        throw new InvalidOperationException("Cannot remove all Ts for a Mod.");
    }

    public bool Contains(T item)
    {
        return _set.Contains(item);
    }

    public void CopyTo(T[] array, int arrayIndex)
    {
        _set.CopyTo(array, arrayIndex);
    }

    public void ExceptWith(IEnumerable<T> other)
    {
        if (IsSubsetOf(other))
        {
            throw new InvalidOperationException("Cannot remove all Ts for a Mod.");
        }

        _set.ExceptWith(other);
    }

    public IEnumerator<T> GetEnumerator()
    {
        return _set.GetEnumerator();
    }

    public void IntersectWith(IEnumerable<T> other)
    {
        if (Overlaps(other) == false)
        {
            throw new InvalidOperationException("Cannot remove all Ts for a Mod.");
        }

        _set.IntersectWith(other);
    }

    public bool IsProperSubsetOf(IEnumerable<T> other)
    {
        return _set.IsProperSubsetOf(other);
    }

    public bool IsProperSupersetOf(IEnumerable<T> other)
    {
        return _set.IsProperSupersetOf(other);
    }

    public bool IsSubsetOf(IEnumerable<T> other)
    {
        return _set.IsSubsetOf(other);
    }

    public bool IsSupersetOf(IEnumerable<T> other)
    {
        return _set.IsSupersetOf(other);
    }

    public bool Overlaps(IEnumerable<T> other)
    {
        return _set.Overlaps(other);
    }

    public bool Remove(T item)
    {
        if (Count == 1)
        {
            throw new InvalidOperationException("Cannot remove last T for a Mod.");
        }

        return _set.Remove(item);
    }

    public bool SetEquals(IEnumerable<T> other)
    {
        return _set.SetEquals(other);
    }

    public void SymmetricExceptWith(IEnumerable<T> other)
    {
        _set.SymmetricExceptWith(other);
    }

    public void UnionWith(IEnumerable<T> other)
    {
        _set.UnionWith(other);
    }

    void ICollection<T>.Add(T item)
    {
        _set.Add(item);
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return _set.GetEnumerator();
    }
}
