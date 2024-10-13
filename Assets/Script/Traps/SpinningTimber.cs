using UnityEngine;

namespace Script.Traps
{
    public class SpinningTimber : MonoBehaviour
    {
        [SerializeField] private GameObject timber;
        [SerializeField] private float timberSpeed;
    
        private void Update()
        {
            timber.transform.Rotate(Vector3.up,  timberSpeed * Time.deltaTime);
        }
    }
}
