using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

namespace GameJam.UI
{
    public class Timer : MonoBehaviour
    {
        private Text timerText;
        private int currTime = 60;
        private bool isTimerOn = false;
        private readonly string FORMAT = "#00";
        private readonly string WORDS = "Timer : ";
        public static event Action OnGameFinished = delegate { };

        private void Awake()
        {
            if (timerText == null)
            {
                timerText = GetComponent<Text>();
            }
        }

        private void OnEnable()
        {
            Countdown.OnGameStart += TurnOnTimer;
            timerText.text = "";
        }

        private IEnumerator StartTimerRoutine()
        {
            while (isTimerOn && currTime >= 0)
            {
                timerText.text = WORDS + currTime.ToString(FORMAT);
                currTime--;
                yield return new WaitForSeconds(1);
            }//timer loop
            OnGameFinished();
            Debug.Log("GAME DONE");
        }

        public void TurnOnTimer()
        {
            if (!isTimerOn)
            {
                isTimerOn = true;
                gameObject.SetActive(true);
                StartCoroutine(StartTimerRoutine());
            }
        }

        private void OnDisable()
        {
            Countdown.OnGameStart -= TurnOnTimer;
        }
    }
}