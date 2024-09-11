
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

        public Pool( GameObject prefab , int count,Transform container)
        {
            _prefab = prefab;
            _poolCountMax = count;
            _container = container;

            for(int i = 0;i < _poolCountMax; i++)
            {
                GameObject obj = Instantiate(_prefab);
                obj.transform.parent = _container;
                obj.SetActive(false);
                _pools.Add(obj);
            }
        }

        public GameObject Get()
        {
            var obj = _pools.FirstOrDefault(x => x.activeInHierarchy == false);

            if(obj == null)
            {
                obj = Create();
            }
            obj.SetActive(true);
            return obj;
        }

        private GameObject Create()
        {
            GameObject obj = Instantiate( _prefab);
            _pools.Add(obj);
            return obj;
        }
    }
}
