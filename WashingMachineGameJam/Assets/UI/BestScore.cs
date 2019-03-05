using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace GameJam.UI
{
    public class BestScore : MonoBehaviour
    {
        private Text scoreText;
        private void OnEnable()
        {
            scoreText = GetComponent<Text>();
            var score = PlayerPrefs.GetInt(GameConstants.Constants.SAVE_SCORE);
            if(score == 0)
            {
                scoreText.text = "";
                return;
            }

            scoreText.text = "Best: " + PlayerPrefs.GetInt(GameConstants.Constants.SAVE_SCORE).ToString();
        }
    }
}
