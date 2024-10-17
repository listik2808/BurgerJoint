using Scripts.Bot;
using Scripts.BotControll;
using UnityEngine;

namespace Scripts.TreggerZone
{
    public class TriggerZonaBot : MonoBehaviour
    {
        [SerializeField] private QueueVisitors _queueVisitors;
        [SerializeField] private ControllingActivationBots _controllingActivationBots;

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out BotMove botMove))
            {
                if(botMove.BurgerPay == false)
                {
                    if (_queueVisitors.FreeCashRegister == true)
                    {
                        botMove.SetPoint(_queueVisitors.transform);
                        _queueVisitors.SetBoolQueue(false);
                        _queueVisitors.SetQueueVisitor(botMove);
                    }
                    else
                    {
                        BotMove bot = _queueVisitors.BacBot;
                        botMove.SetPoint(bot.transform);
                        _queueVisitors.SetQueueVisitor(botMove);
                    }
                }
                else
                {
                    botMove.DiactivateBot();
                    _controllingActivationBots.ResetBot(botMove);
                }
            }
        }
    }
}
