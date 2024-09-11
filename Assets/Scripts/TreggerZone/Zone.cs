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
        private GameObject _createdObject;
        private float _elepsedTime;

        private void OnEnable()
        {
            _work.BurgerReady += ActivateBurger;
        }

        private void OnDisable()
        {
            _work.BurgerReady -= ActivateBurger;
        }

        private void OnTriggerEnter(Collider other)
        {
            if(other.TryGetComponent(out HeroMove heroMove))
            {
                _work.ActivateBackgrounImage();
            }
        }

        private void OnTriggerStay(Collider other)
        {
            if(other.TryGetComponent(out HeroMove hero))
            {
                _elepsedTime += Time.deltaTime;
                if (_elepsedTime >= _timeSecMax && _createdObject == null)
                {
                    _work.RunWork(_timeWorkSec);
                    _elepsedTime = 0;
                }
                else if(_createdObject != null)
                {

                }
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.TryGetComponent(out HeroMove hero))
            {
                _work.ResettingWorkProgress();
                _work.DeactivateBackgrounImage();
            }
        }

        private void ActivateBurger()
        {
            _createdObject = _pool.Get();
            _createdObject.transform.position = _transformPoint.position; 
        }
    }
}
