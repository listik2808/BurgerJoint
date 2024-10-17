using Scripts.Bot;
using Scripts.TreggerZone;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Scripts
{
    public class QueueVisitors : MonoBehaviour
    {
        [SerializeField] private CanvasGroup _canvasGroup;
        [SerializeField] private TriggerZonaBot _zonaBot;
        private bool _freeCashRegister = true;
        private List<BotMove> _movesBot = new List<BotMove>();
        private BotMove _currentClient;
        private BotMove _bacBot;

        public BotMove CurrentClient => _currentClient;
        public bool FreeCashRegister => _freeCashRegister;
        public List<BotMove> BotMoves => _movesBot;
        public BotMove BacBot => _bacBot;

        public void SetBoolQueue(bool value)
        {
            _freeCashRegister = value;
        }

        public void SetQueueVisitor(BotMove botMove)
        {
            _movesBot.Add(botMove);
            _bacBot = botMove;
        }

        public void Next()
        {
            _currentClient.PayBurger();
            _movesBot.Remove(_currentClient);
            _currentClient.SetPoint(_zonaBot.transform);
            _currentClient = _movesBot.FirstOrDefault(x => x.BurgerPay == false);
            _currentClient.SetPoint(transform);
        }

        private void OnTriggerEnter(Collider other)
        {
            if(other.TryGetComponent(out BotMove botMove))
            {
                _currentClient = botMove;
                _canvasGroup.alpha = 1;
                botMove.ActivateImage();
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if(other.TryGetComponent(out BotMove botMove))
            {
                if(botMove == _currentClient)
                {
                    _canvasGroup.alpha = 0;
                }
            }
        }
    }
}
