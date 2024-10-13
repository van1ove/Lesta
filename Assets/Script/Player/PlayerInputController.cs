using UnityEngine;
using UnityEngine.InputSystem;

namespace Script.Player
{
    [RequireComponent(typeof(CharacterController), typeof(PlayerPhysicsController), 
        typeof(PlayerAnimatorController))]
    public class PlayerInputController : MonoBehaviour
    {
        private const float Gravity = -9.81f;
        private bool _isBlocked;

        [Header("General")] 
        private PlayerPhysicsController _physicsController;
        private PlayerAnimatorController _animatorController;
        private CharacterController _characterController;
        private Vector3 _direction;
        private Vector2 _moveInput;
        
        [Header("Movement")]
        [SerializeField] private float speed = 5.0f;
        [SerializeField] private float jumpPower;
        
        [Header("Rotation")]
        [SerializeField] private float smoothTime = 0.05f;
        private float _currentVelocity;

        [Header("Gravity")]
        [SerializeField] private float gravityMultiplier = 3f;
        private float _verticalVelocity;
        
        private void Start()
        {
            _isBlocked = false;
            _physicsController = GetComponent<PlayerPhysicsController>();
            _animatorController = GetComponent<PlayerAnimatorController>();
            _characterController = GetComponent<CharacterController>();
            _direction = new Vector3();
        }

        private void Update()
        {
            _animatorController.UpdateAnimator(_moveInput.sqrMagnitude > 0);
            _physicsController.CheckCollision();

            if (_isBlocked)
                return;
            
            ApplyGravity();
            MovePlayer();

            if (_moveInput.sqrMagnitude == 0)
                return;

            RotatePlayer();
        }

        public void BlockInputState(bool state) => _isBlocked = state;
        
        public void Move(InputAction.CallbackContext context)
        {
            _moveInput = context.ReadValue<Vector2>();
            _direction.x = _moveInput.x;
            _direction.z = _moveInput.y;
        }

        public void Jump(InputAction.CallbackContext context)
        {
            if (!context.started)
                return;

            if (!_characterController.isGrounded)
                return;

            _verticalVelocity += jumpPower;
        }
        
        private void MovePlayer()
        {
            _characterController.Move(_direction * speed * Time.deltaTime);
        }
    
        private void RotatePlayer()
        {
            float targetAngle = Mathf.Atan2(_direction.x, _direction.z) * Mathf.Rad2Deg;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref _currentVelocity, smoothTime);
            transform.rotation = Quaternion.Euler(0, angle, 0);
        }

        private void ApplyGravity()
        {
            if (_characterController.isGrounded && _verticalVelocity < 0)
            {
                _verticalVelocity = -1f;
            }
            else
            {
                _verticalVelocity += Gravity * Time.deltaTime * gravityMultiplier;
            }
            
            _direction.y = _verticalVelocity;
        }
        
    }
}
