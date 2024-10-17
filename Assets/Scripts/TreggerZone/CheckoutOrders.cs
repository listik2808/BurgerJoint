using Scripts.Bot;
using Scripts.Hero;
using Scripts.Workflow;
using UnityEngine;

namespace Scripts.TreggerZone
{
    public class CheckoutOrders : MonoBehaviour
    {
        [SerializeField] private Work _work;
        [SerializeField] private QueueVisitors _visitors;
        [SerializeField] private float _timeWorkSec = 0.05f;
        [SerializeField] private Wallet _wallet;
        private HeroAnimation hero;

        private void OnEnable()
        {
            _work.Pay += PayBurger;
        }

        private void OnDisable()
        {
            _work.Pay -= PayBurger; ;
        }

        private void OnTriggerStay(Collider other)
        {
            if(_visitors.CurrentClient != null && other.TryGetComponent(out HeroAnimation heroAnimation))
            {
                if (heroAnimation.Target != null)
                {
                    _work.RunWork(_timeWorkSec);
                }
                else
                {
                    _work.DeactivateBackgrounImage();
                    _work.ResettingWorkProgress();
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

        private void OnTriggerEnter(Collider other)
        {
            if(_visitors.CurrentClient != null && other.TryGetComponent(out HeroAnimation heroAnimation))
            {
                if (heroAnimation.Target != null)
                {
                    hero = heroAnimation;
                    _work.ActivateBackgrounImage();
                }
            }
        }

        private void PayBurger(float value)
        {
            if (_visitors.CurrentClient.BurgerPay == false)
            {
                _wallet.AddMoney(value);
                _visitors.CurrentClient.SetPointBurger(hero.Target);
                _visitors.CurrentClient.DiactivateImage();
                hero.Give();
                _visitors.Next();
            }
        }
    }
}
