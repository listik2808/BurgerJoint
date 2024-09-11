using UnityEngine;

namespace Scripts.Hero
{
    public class HeroAnimation : MonoBehaviour
    {
        private const string IsMove = "IsMove";

        [SerializeField] private Animator _animator;
        [SerializeField] private CharacterController _characterController;

        private void Update()
        {
            if (_characterController.velocity.sqrMagnitude > 0.05f)
                _animator.SetBool(IsMove, true);
            else
                _animator.SetBool(IsMove, false);
        }
    }
}
