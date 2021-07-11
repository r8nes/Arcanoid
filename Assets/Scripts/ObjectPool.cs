using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] private int AmountToPool;
    [SerializeField] private GameObject _object;
    private readonly List<GameObject> _objects = new List<GameObject>();

    private void OnEnable()
    {
        CreatePool();
    }

    private void CreatePool()
    {
        _objects.Clear();
        GameObject temp;
        for (int i = 0; i < AmountToPool; i++)
        {
            temp = Instantiate(_object);
            _object.SetActive(false);
            _objects.Add(temp);
        }
    }

    public GameObject GetBullet()
    {
        for (int i = 0; i < _objects.Count; i++)
        {
            if (!_objects[i].activeInHierarchy)
            {
                return _objects[i];
            }
        }
        return null;
    }
}
