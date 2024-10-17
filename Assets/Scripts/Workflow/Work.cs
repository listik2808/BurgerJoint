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
        [SerializeField] private float _price;
        private float _min;
        private bool _active = false;

        public float Price => _price;

        public event Action Ready;
        public event Action<float> Pay;

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
            if(_min >= _timeWorkMax && _active ==false)
            {
                _active = true;
                Ready?.Invoke();
                Pay?.Invoke(_price);
            }
            else 
            {
                _min += elepsedTime;
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
            _active = false;
        }
    }
}
