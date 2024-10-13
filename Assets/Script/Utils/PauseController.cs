using UnityEngine;
using UnityEngine.Events;

namespace Script.Utils
{
    public class PauseController : MonoBehaviour
    {
        public UnityEvent onGamePaused;
        public UnityEvent onGameContinue;
        private void Start()
        {
            ContinueTime();
        }

        private void Update()
        {
            if (!Input.GetKeyDown(KeyCode.Escape)) 
                return;

            if (Time.timeScale < 0.01)
            {
                onGameContinue?.Invoke();
            }
            else
            {
                onGamePaused?.Invoke();
            }
        }

        public void StopTime() => Time.timeScale = 0f;

        public void ContinueTime() => Time.timeScale = 1f;
    }
}