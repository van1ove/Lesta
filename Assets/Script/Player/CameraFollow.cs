using UnityEngine;

namespace Script.Player
{
    public class CameraFollow : MonoBehaviour
    {
        [SerializeField] private Transform target; 
        [SerializeField] private Vector3 offset;

        void LateUpdate()
        {
            transform.position = target.position + offset;
        }
    }
}
