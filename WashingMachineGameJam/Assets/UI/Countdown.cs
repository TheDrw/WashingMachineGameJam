using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

namespace GameJam.UI
{
    public class Countdown : MonoBehaviour
    {
        public static event Action OnGameStart = delegate { };

        private Text countdownText;
        private string[] countdownWords = { "3", "2", "1", "Go!" };

        private void Awake()
        {
            if(countdownText == null)
            {
                countdownText = GetComponent<Text>();
            }
        }

        private void OnEnable()
        {
            countdownText.text = "";
            StartCoroutine(CountdownRoutine());
        }

        private IEnumerator CountdownRoutine()
        {
            countdownText.fontSize = 70;
            yield return new WaitForSeconds(1f);
            countdownText.text = "Hold Left Mouse Button";
            yield return new WaitForSeconds(1.5f);
            countdownText.text = "Flick While Holding";
            yield return new WaitForSeconds(1.5f);
            countdownText.text = "Release That Button";
            yield return new WaitForSeconds(1.5f);
            countdownText.text = "Go Toss N' Wash!!";
            yield return new WaitForSeconds(2f);
            countdownText.fontSize = 250;
            for (int i = 0; i < countdownWords.Length; i++)
            {
                countdownText.text = countdownWords[i];
                yield return new WaitForSeconds(1f);
            }

            OnGameStart();
            gameObject.SetActive(false);
        }

        private void OnDisable()
        {
            StopAllCoroutines();
        }
    }
}