using Scripts.CameraLogic;
using Scripts.Infrastructure;
using Scripts.Input;
using UnityEngine;

namespace Scripts.Hero
{
    [RequireComponent(typeof (CharacterController))]
    public class HeroMove : MonoBehaviour
    {
        [SerializeField] private CharacterController _characterController;
        [SerializeField] private float _movementSpeed;
        private Camera _camera;
        private IInputService _input;

        private void Awake()
        {
            _input = Game.InputService;
        }

        private void Start()
        {
            _camera = Camera.main;
            CameraFollow();
        }

        private void Update()
        {
            Vector3 movementVector = Vector3.zero;

            if(_input.Axis.sqrMagnitude > 0.001f)
            {
                movementVector = _camera.transform.TransformDirection(_input.Axis);
                movementVector.y = 0f;
                movementVector.Normalize();

                transform.forward = movementVector;
            }
            movementVector += Physics.gravity;

            _characterController.Move(_movementSpeed * movementVector * Time.deltaTime);
        }

        private void CameraFollow()
        {
            _camera.GetComponent<CameraFollow>().Follow(gameObject);
        }
    }
}
