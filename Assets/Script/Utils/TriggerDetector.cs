using UnityEngine;
using UnityEngine.Events;

namespace Script.Utils
{
    public class TriggerDetector : MonoBehaviour
    {
        public UnityEvent onTriggerEnterEvent;

        private void OnTriggerEnter(Collider other)
        {
            onTriggerEnterEvent?.Invoke();
        }
    }
}