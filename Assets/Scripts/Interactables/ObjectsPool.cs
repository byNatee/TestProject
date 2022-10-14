using System;
using System.Collections.Generic;
using UnityEngine;

namespace Interactables
{
    public class ObjectsPool : MonoBehaviour
    {
        [SerializeField] private GameObject _objectPrefab;
        [SerializeField] private Transform _container;
        [SerializeField] private bool _autoExpand;
        [SerializeField] private int _minCapacity;

        private List<GameObject> _pool;

        private void Awake()
        {
            InitPool();
        }

        private void InitPool()
        {
            _pool = new List<GameObject>();

            for (var i = 0; i < _minCapacity; i++)
                CreateObject();
        }

        private GameObject CreateObject(bool defaultCondition = false)
        {
            var createdObject = Instantiate(_objectPrefab, _container);
            createdObject.SetActive(defaultCondition);
            _pool.Add(createdObject);
            return createdObject;
        }

        public GameObject GetFreeObject()
        {
            if (HasFreeObject(out var element))
                return element;

            if (_autoExpand)
                return CreateObject(true);

            throw new Exception("There is no free element and not auto expand");
        }

        private bool HasFreeObject(out GameObject element)
        {
            foreach (var item in _pool)
            {
                if (!item.activeInHierarchy)
                {
                    element = item;
                    element.SetActive(true);
                    return true;
                }
            }

            element = null;
            return false;
        }
    }
}
