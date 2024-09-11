using System;
using UnityEngine;
using UnityEngine.UI;

namespace Scripts.Workflow
{
    public class Work : MonoBehaviour,IWork
    {
        [SerializeField] private Image _icon;
        [SerializeField] private Image _imageBackgraund;
        [SerializeField] private float _timeWorkMax;
        private float _min;

        public event Action BurgerReady;

        private void Start() 
        {
            ResettingWorkProgress();
        }

        public void ResettingWorkProgress()
        {
            _icon.fillAmount = 0;
            _min = 0;
        }

        public void RunWork(float elepsedTime)
        {
            if(_min == _timeWorkMax)
            {
                BurgerReady?.Invoke();
            }
            else 
            {
                _min += Time.deltaTime;
                _icon.fillAmount = _min / _timeWorkMax;
            }
            
        }

        public void ActivateBackgrounImage()
        {
            _imageBackgraund.gameObject.SetActive(true);
        }

        public void DeactivateBackgrounImage()
        {
            _imageBackgraund.gameObject.SetActive(false);
        }
    }
}
