using UnityEngine;

public class Molot : MonoBehaviour
{
    public float rotationSpeed = 30f;
    private float currentRotation = 30f;
    private bool rotateClockwise = true;

    void Update()
    {
        if (rotateClockwise)
        {
            currentRotation += rotationSpeed * Time.deltaTime;
            if (currentRotation >= 30f)
            {
                currentRotation = 30f;
                rotateClockwise = false;
            }
        }
        else
        {
            currentRotation -= rotationSpeed * Time.deltaTime;
            if (currentRotation <= -30f)
            {
                currentRotation = -30f;
                rotateClockwise = true;
            }
        }

        transform.rotation = Quaternion.Euler(0f, 0f, currentRotation);
    }
}
