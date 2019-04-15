using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GameJam.Interactables;

namespace GameJam.UI
{
    public class Score : MonoBehaviour
    {
        private Text scoreText;
        private int currentScore = 0;
        private readonly string FORMAT = "#00000";

        private void Awake()
        {
            scoreText = GetComponent<Text>();
        }

        private void OnEnable()
        {
            scoreText.text = "";
            Countdown.OnGameStart += ShowScore;
            Timer.OnGameFinished += RecordScore;
            Goal.OnItemInGoal += UpdateScore;
        }

        private void ShowScore()
        {
            scoreText.text = currentScore.ToString(FORMAT);
        }

        private void UpdateScore(int score)
        {
            currentScore += score;
            scoreText.text = currentScore.ToString(FORMAT);
        }

        // while playerprefs is nice and easy, i wouldn't use it for an actual game.
        // score can be accessd easily and changed on client side.
        // so this is cheating prone. good enough for a game jam
        private void RecordScore()
        {
            var currentHighScore = PlayerPrefs.GetInt(Utility.GameConstants.SAVE_SCORE);
            currentHighScore = currentScore > currentHighScore ? currentScore : currentHighScore;
            PlayerPrefs.SetInt(Utility.GameConstants.SAVE_SCORE, currentHighScore);
            PlayerPrefs.Save();
        }

        private void OnDisable()
        {
            Countdown.OnGameStart -= ShowScore;
            Timer.OnGameFinished -= RecordScore;
            Goal.OnItemInGoal -= UpdateScore;
        }
    }
}