using UnityEngine;

public class WindPlatform : MonoBehaviour
{
    [SerializeField] GameObject arrowCanvas;
    [SerializeField] private float windForce = 10.0f;
    [SerializeField] private float windChangeTime = 3.0f;

    private Quaternion offset = Quaternion.Euler(90, 0, 0);
    private Vector3 windDirection;
    
    private void Start()
    {
        InvokeRepeating(nameof(ChangeWindDirection), 0, windChangeTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out CharacterController playerController))
        {
            playerController.Move(windDirection.normalized * windForce * Time.deltaTime);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.TryGetComponent(out CharacterController playerController))
        {
            playerController.Move(windDirection.normalized * windForce * Time.deltaTime);
        }
    }

    private void ChangeWindDirection()
    {
        do
        {
            windDirection = Random.insideUnitSphere;
            windDirection.y = 0;
        } while (windDirection.z > 0);

        arrowCanvas.transform.right = windDirection;
        arrowCanvas.transform.rotation *= offset;
    }
}
