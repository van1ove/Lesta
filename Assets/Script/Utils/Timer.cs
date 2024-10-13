using System;
using TMPro;
using UnityEngine;

namespace Script.Utils
{
    public class Timer : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI timeTMP;
        public bool IsStopped { get; private set; }
        public float CurrentTime { get; private set; }

        private bool _isStarted;

        private void Start()
        {
            IsStopped = true;
            CurrentTime = 0f;
            _isStarted = false;
        }

        private void Update()
        {
            if (IsStopped)
                return;

            _isStarted = true;

            CurrentTime += Time.deltaTime;
        }

        public void PauseTimer(bool pause = false)
        {
            if (!_isStarted)
                return;

            IsStopped = pause;
        }

        public void UnlockTimer() => _isStarted = true;

        public void ShowTime()
        {
            string time = CurrentTime.ToString();
            string[] splited = time.Split(',');
            int seconds = Int16.Parse(splited[0]);
            Debug.Log(CurrentTime);
            timeTMP.text = "Время - " + (int)seconds / 60 + ":" + seconds % 60 
                           + ":" + splited[1].Substring(0, 2);
        }
    }
}