
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Scripts.CustomPool
{
    public class Pool : MonoBehaviour
    {
        private Transform _container;
        private GameObject _prefab;
        [Min(0)] private int _poolCountMax;
        private List<GameObject> _pools = new List<GameObject>();

        public Transform Container => _container;

        public event Action IsRedy;

        public void Construct( GameObject prefab , int count,Transform container)
        {
            _prefab = prefab;
            _poolCountMax = count;
            _container = container;

            for(int i = 0;i < _poolCountMax; i++)
            {
                GameObject obj = Instantiate(_prefab,_container);
                obj.SetActive(false);
                _pools.Add(obj);
            }
            IsRedy?.Invoke();
        }

        public GameObject Get()
        {
            var obj = _pools.FirstOrDefault(x => x.activeInHierarchy == false);

            if(obj == null)
            {
                obj = Create();
            }
            obj.SetActive(true);
            obj.transform.parent = _container;
            return obj;
        }


        private GameObject Create()
        {
            GameObject obj = Instantiate( _prefab,_container);
            _pools.Add(obj);
            return obj;
        }
    }
}
