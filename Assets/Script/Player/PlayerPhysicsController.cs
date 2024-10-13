using System;
using Script.Utils;
using UnityEngine;

namespace Script.Player
{
    public class PlayerPhysicsController : MonoBehaviour
    {
        private CharacterController _characterController;
        private Vector3 _bottom;
        private Vector3 _top;
        
        private void Start()
        {
            _characterController = GetComponent<CharacterController>();
        }

        public void CheckCollision()
        {
            _bottom = transform.position + Vector3.up * 0.25f + Vector3.forward / 3;
            _top = _bottom + Vector3.up * (_characterController.height * transform.localScale.y);
        
            for (int i = 0; i < 360; i += 12)
            {
                if (Physics.CapsuleCast(_bottom, _top, 0, new Vector3(Mathf.Cos(i), 0, Mathf.Sin(i)), 
                        out RaycastHit hit, _characterController.radius, 1 << LayerMaskIndexContainer.SpinningTrap))
                {
                    _characterController.Move(hit.normal * (_characterController.radius - hit.distance) * 0.3f);
                }
            }
        }
    }
}