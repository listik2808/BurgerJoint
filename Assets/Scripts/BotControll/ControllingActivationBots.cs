using Scripts.Bot;
using Scripts.CustomPool;
using Scripts.Hero;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts.BotControll
{
    public class ControllingActivationBots : MonoBehaviour
    {
        [SerializeField] private Pool _pool;
        [SerializeField] private QueueVisitors _visitors;
        [SerializeField] private GameObject _transformPoint;
        [SerializeField] private int _maxCountBot = 5;
        private int currentBot = 0;
        private List<BotMove> _botMove = new List<BotMove>();
        Coroutine _coroutine;

        public event Action<BotMove> Reset;

        private void OnEnable()
        {
            _pool.IsRedy += StartActivateHumonBot;
        }

        private void OnDisable()
        {
            _pool.IsRedy -= StartActivateHumonBot;
        }

        public void ResetBot(BotMove botMove)
        {
            currentBot--;
            botMove.transform.SetParent(transform);
            if(currentBot <=1 )
                StartActivateHumonBot();
        }

        private IEnumerator ActivateHumenBot()
        {
            while(_maxCountBot  > currentBot)
            {
                GameObject humon = _pool.Get();
                currentBot++;
                if(humon.TryGetComponent(out BotMove botMove))
                {
                    _botMove.Add(botMove);
                    botMove.ActivateMove();
                    botMove.SetPoint(_transformPoint.transform);
                }
                yield return new WaitForSeconds(3.5f);
            }
        }

        private void StartActivateHumonBot()
        {
            if (_coroutine != null)
                StopCoroutine(_coroutine);

            _coroutine = StartCoroutine(ActivateHumenBot());
        }
    }
}
