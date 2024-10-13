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

        private void Start()
        {
            IsStopped = true;
            CurrentTime = 0f;
        }

        private void Update()
        {
            if (IsStopped)
                return;

            CurrentTime += Time.deltaTime;
        }

        public void PauseTimer(bool pause = false) => IsStopped = pause;

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