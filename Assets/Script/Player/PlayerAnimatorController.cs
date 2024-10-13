using UnityEngine;

namespace Script.Player
{
    public class PlayerAnimatorController : MonoBehaviour
    {
        private readonly int _speedIndex = Animator.StringToHash("Speed");
        
        [SerializeField] private float speedMultiplier;
        private Animator _animator;
        private float _speed;
        private void Start()
        {
            _animator = GetComponent<Animator>();
        }

        public void UpdateAnimator(bool isMoving = false)
        {
            _speed = isMoving ? Mathf.Clamp(_speed + Time.deltaTime * speedMultiplier * 2, 0, 1) : 
                Mathf.Clamp(_speed - Time.deltaTime * speedMultiplier, 0, 1);

            _animator.SetFloat(_speedIndex, _speed);
        }
    }
}
