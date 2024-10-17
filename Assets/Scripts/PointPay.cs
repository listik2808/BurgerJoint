using Scripts.Bot;
using UnityEngine;

namespace Scripts
{
    public class PointPay : MonoBehaviour
    {
        private bool _freePoint = true;
        private BotMove _botMove;

        public bool FreePoint => _freePoint;

        public void TakePlace(BotMove botMove)
        {
            _botMove = botMove;
            _freePoint = false;
        }
    }
}
