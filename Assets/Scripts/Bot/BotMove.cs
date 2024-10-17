using Scripts.CustomPool;
using System;
using UnityEngine;
using UnityEngine.AI;

namespace Scripts.Bot
{
    public class BotMove : MonoBehaviour
    {
        private const string IsMove = "IsMove";

        [SerializeField] private NavMeshAgent _agent;
        [SerializeField] private Transform _point;
        [SerializeField] private CanvasGroup _canvasGroup;
        [SerializeField] private Animator _animator;
        private Burger _burger1;
        private Transform _pointPay;
        private bool _burgerPay = false;

        public bool BurgerPay => _burgerPay;


        private void Update()
        {
            if (_pointPay!= null)
            {
                if ((_agent.transform.position - _pointPay.transform.position).magnitude <= _agent.stoppingDistance)
                {
                    _animator.SetBool(IsMove, false);
                    _pointPay = null;
                    //return;
                }
                else 
                {
                    _animator.SetBool(IsMove, true);
                    _agent.SetDestination(_pointPay.transform.position);
                }
                
            }
            
        }

        public void SetPointBurger(Burger burger)
        {
            _burger1 = burger;
            burger.transform.position = _point.transform.position;
            burger.transform.parent = _point.transform;
        }

        public void PayBurger()
        {
            _burgerPay = true;
        }

        public void ActivateMove()
        {
            _agent.enabled = true;
            _burgerPay = false;
        }

        public void SetPoint(Transform point) 
        {
            _pointPay = point;
        }

        public void ActivateImage()
        {
            _canvasGroup.alpha = 1;
        }

        public void DiactivateImage()
        {
            _canvasGroup.alpha = 0;
        }

        public void DiactivateBot()
        {
            _pointPay = null;
            _agent.enabled = false;
            _burgerPay = false;
            _burger1.ResetPositionBurger();
            gameObject.SetActive(false);
        }
    }
}
