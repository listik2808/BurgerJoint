using Scripts.Hero;
using Scripts.Workflow;
using UnityEngine;

namespace Scripts.TreggerZone
{
    public class Zone : MonoBehaviour
    {
        [SerializeField] private Work _work;
        [SerializeField] private float _timeWorkSec;
        [SerializeField] private float _elepsedTimeSecMax;
        private float _elepsedTime;

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
                _elepsedTime += _timeWorkSec + Time.deltaTime;
                if (_elepsedTime >= _elepsedTimeSecMax)
                {
                    _work.RunWork(_elepsedTime);
                    _elepsedTime = 0;
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
    }
}
