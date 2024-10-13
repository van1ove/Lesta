using UnityEngine;

namespace Script.Traps
{
    public class FallingHammer : MonoBehaviour
    {
        [SerializeField] private float rotationSpeed = 30f;
        [SerializeField] private float startRotation = 30f;
        private bool _rotateClockwise;

        private void Start()
        {
            _rotateClockwise = true;
        }

        private void Update()
        {
            if (_rotateClockwise)
            {
                startRotation += rotationSpeed * Time.deltaTime;
                if (startRotation >= 30f)
                {
                    startRotation = 30f;
                    _rotateClockwise = false;
                }
            }
            else
            {
                startRotation -= rotationSpeed * Time.deltaTime;
                if (startRotation <= -30f)
                {
                    startRotation = -30f;
                    _rotateClockwise = true;
                }
            }

            transform.rotation = Quaternion.Euler(0f, 0f, startRotation);
        }
    }
}
