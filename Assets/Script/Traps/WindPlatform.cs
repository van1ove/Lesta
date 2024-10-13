using UnityEngine;

namespace Script.Traps
{
    public class WindPlatform : MonoBehaviour
    {
        [SerializeField] private GameObject arrowCanvas;
        [SerializeField] private float windForce = 10.0f;
        [SerializeField] private float windChangeTime = 3.0f;

        private readonly Quaternion _offset = Quaternion.Euler(90, 0, 0);
        private Vector3 _windDirection;
    
        private void Start()
        {
            InvokeRepeating(nameof(ChangeWindDirection), 0, windChangeTime);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out CharacterController playerController))
            {
                playerController.Move(_windDirection.normalized * windForce * Time.deltaTime);
            }
        }

        private void OnTriggerStay(Collider other)
        {
            if (other.TryGetComponent(out CharacterController playerController))
            {
                playerController.Move(_windDirection.normalized * windForce * Time.deltaTime);
            }
        }

        private void ChangeWindDirection()
        {
            do
            {
                _windDirection = Random.insideUnitSphere;
                _windDirection.y = 0;
            } while (_windDirection.z > 0);

            arrowCanvas.transform.right = _windDirection;
            arrowCanvas.transform.rotation *= _offset;
        }
    }
}
