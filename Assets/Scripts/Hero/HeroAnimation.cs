using System;
using UnityEngine;

namespace Scripts.Hero
{
    public class HeroAnimation : MonoBehaviour
    {
        private const string IsMove = "IsMove";
        private const string IsGrab = "IsGrab";

        [SerializeField] private Animator _animator;
        [SerializeField] private CharacterController _characterController;
        [SerializeField] private Transform _pointGrab;

        private GameObject _target;

        public GameObject Target => _target;

        private void Update()
        {
            if (_characterController.velocity.sqrMagnitude > 0.05f)
                _animator.SetBool(IsMove, true);
            else
                _animator.SetBool(IsMove, false);
        }

        public void Take(GameObject burger)
        {
            _target = burger;
            _animator.SetTrigger(IsGrab);
        }

        public void SetParentBurger()
        {
            _target.transform.position  = _pointGrab.position;
            _target.transform.parent = _pointGrab;
        }
    }
}
