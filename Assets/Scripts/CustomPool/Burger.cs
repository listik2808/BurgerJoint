using UnityEngine;

namespace Scripts.CustomPool
{
    public class Burger : MonoBehaviour
    {
        private Transform _startPosition;
        public Transform StartPosition => _startPosition;

        public void TrySetPosition(Transform transformPoint)
        {
            _startPosition = transformPoint;
        }

        public void ResetPositionBurger()
        {
            transform.parent = _startPosition;
            transform.position = _startPosition.position;
            gameObject.SetActive(false);
        }
    }
}
