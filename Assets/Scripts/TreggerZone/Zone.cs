using Scripts.CustomPool;
using Scripts.Hero;
using Scripts.Workflow;
using UnityEngine;

namespace Scripts.TreggerZone
{
    public class Zone : MonoBehaviour
    {
        [SerializeField] private Work _work;
        [SerializeField] private Pool _pool;
        [SerializeField] private float _timeWorkSec;
        [SerializeField] private float _timeSecMax;
        [SerializeField] private Transform _transformPoint;
        private Burger _burger;
        private float _elepsedTime;

        private void OnEnable()
        {
            _work.Ready += ActivateBurger;
        }

        private void OnDisable()
        {
            _work.Ready -= ActivateBurger;
        }

        private void OnTriggerEnter(Collider other)
        {
            if(other.TryGetComponent(out HeroAnimation heroAnimation))
            {
                if(heroAnimation.Target == null)
                    _work.ActivateBackgrounImage();
            }
        }

        private void OnTriggerStay(Collider other)
        {
            if(other.TryGetComponent(out HeroAnimation hero))
            {
                _elepsedTime += Time.deltaTime;
                if (_elepsedTime >= _timeSecMax && _burger == null)
                {
                    _work.RunWork(_timeWorkSec);
                    _elepsedTime = 0;
                }
                else if(_burger != null && hero.Target == null)
                {
                    hero.Take(_burger);
                }
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.TryGetComponent(out HeroAnimation hero))
            {
                _work.ResettingWorkProgress();
                _work.DeactivateBackgrounImage();
                if(hero.Target != null)
                    _burger = null;
            }
        }

        private void ActivateBurger()
        {
            GameObject obj = _pool.Get();
            if(obj.TryGetComponent(out Burger burger))
            {
                _burger = burger;
                burger.TrySetPosition(_pool.Container);
            }
            _burger.transform.position = _transformPoint.position; 
        }
    }
}
