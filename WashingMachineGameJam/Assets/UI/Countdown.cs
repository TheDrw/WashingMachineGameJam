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

        // I guess I also put my instructions here...lol
        private IEnumerator CountdownRoutine()
        {
            // if player hasn't played before, the score will be zero. Of if they didn't score anything
            // it will show this again.
            int score = PlayerPrefs.GetInt(Utility.GameConstants.SAVE_SCORE);
            if(score == 0)
            {
                countdownText.fontSize = 70;
                yield return new WaitForSeconds(0.75f);
                countdownText.text = "Hold LEFT Mouse Button";
                yield return new WaitForSeconds(2.5f);
                countdownText.text = "Or Hold Left CTRL";
                yield return new WaitForSeconds(2.5f);
                countdownText.text = "Flick the mouse";
                yield return new WaitForSeconds(2f);
                countdownText.text = "Release the button";
                yield return new WaitForSeconds(2f);
                countdownText.text = "Now Toss N' Wash!!";
            }

            yield return new WaitForSeconds(2f);
            countdownText.fontSize = 250;
            for (int i = 0; i < countdownWords.Length; i++)
            {
                countdownText.text = countdownWords[i];
                yield return new WaitForSeconds(0.5f);
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