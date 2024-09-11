using UnityEngine;

namespace Scripts.CustomPool
{
    public class PoolManager : MonoBehaviour
    {
        [SerializeField] private Pool _pool;
        [SerializeField] private Transform _container;
        [SerializeField] private GameObject _prefab;
        [SerializeField] private int _poolCountMax;

        private void Start()
        {
            _pool.Construct(_prefab, _poolCountMax,_container);
        }
    }
}
