using UnityEngine;

namespace Script.Traps
{
    public class FallingHammer : MonoBehaviour
    {
        [SerializeField] private float rotationSpeed = 30f;
        private float _currentRotation = 30f;
        private bool _rotateClockwise;

        private void Start()
        {
            _rotateClockwise = true;
        }

        private void Update()
        {
            if (_rotateClockwise)
            {
                _currentRotation += rotationSpeed * Time.deltaTime;
                if (_currentRotation >= 30f)
                {
                    _currentRotation = 30f;
                    _rotateClockwise = false;
                }
            }
            else
            {
                _currentRotation -= rotationSpeed * Time.deltaTime;
                if (_currentRotation <= -30f)
                {
                    _currentRotation = -30f;
                    _rotateClockwise = true;
                }
            }

            transform.rotation = Quaternion.Euler(0f, 0f, _currentRotation);
        }
    }
}
