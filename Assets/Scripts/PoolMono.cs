using System.Collections.Generic;
using UnityEngine;

public class PoolMono<T> where T: MonoBehaviour
{
    public T _prefab { get; }
    public bool _autoExpand { get; set; }
    public Transform _container { get; }

    private List<T> _pool;

    public PoolMono(T prefab, int count, Transform container)
    {
        _prefab = prefab;
        _container = container;

        CreatePool(count);
    }

    private void CreatePool(int count)
    {
        _pool = new List<T>();

        for(var i = 0; i < count; i++)
            CreateObject();
    }

    private T CreateObject(bool isActiveByDefault = false)
    {
        var createdObject = Object.Instantiate(_prefab, _container);
        createdObject.gameObject.SetActive(isActiveByDefault);
        _pool.Add(createdObject);
        return createdObject;
    }

    public bool HasFreeElement()
    {
        foreach (var mono in _pool)
        {
            if (!mono.gameObject.activeInHierarchy)
            {
                return true;
            }
        }

        return false;
    }

    public T GetFreeElement()
    {
        if (HasFreeElement())
        {
            foreach (var mono in _pool)
            {
                if (!mono.gameObject.activeInHierarchy)
                {
                    mono.gameObject.SetActive(true);
                    return mono;
                }
            }
        }

        if (_autoExpand)
            CreateObject(true);

        throw new System.Exception($"There is no free elements in pool of type {typeof(T)}");
    }
}
