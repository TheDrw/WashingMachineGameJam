using UnityEngine;
using GameJam.Utility;
using GameJam.Core;
using System.Collections;

namespace GameJam.UI
{
    public class InGameUIManager : MonoBehaviour
    {
        [SerializeField]
        private GameObject InGamePanel;

        [SerializeField]
        private GameObject PausePanel;

        [SerializeField]
        private GameObject EndPanel;

        private bool isGameActive = false;
        private bool isGameFinished = false;

        private void Start()
        {
            Countdown.OnGameStart += GameStart;
            Timer.OnGameFinished += GameEnd;
        }

        private void Update()
        {
            if (isGameActive)
            {
                ShowPausePanel();
            }
        }


        private void OnDisable()
        {
            Countdown.OnGameStart -= GameStart;
            Timer.OnGameFinished -= GameEnd;
        }

        private void ShowPausePanel()
        {
            if (Input.GetButtonDown(GameConstants.CANCEL))
            {
                if (!PausePanel.activeSelf)
                {
                    PausePanel.SetActive(true);
                }
            }
        }

        private void GameStart()
        {
            isGameActive = true;
        }

        private void GameEnd()
        {
            isGameActive = false;
            isGameFinished = true;
            StartCoroutine(DelayEndPanel());
        }

        IEnumerator DelayEndPanel()
        {
            yield return new WaitForSeconds(3.1f);
            EndPanel.SetActive(true);
        }

        public void ReturnToGame()
        {
            PausePanel.SetActive(false);
        }

        public void ReturnToMainMenu()
        {
            InGamePanel.SetActive(false);
            PausePanel.SetActive(false);
            EndPanel.SetActive(false);

            if (LevelSelectManager.LevelSelect)
            {
                LevelSelectManager.LevelSelect.ReturnToMainMenu();
            }
        }

        public void Retry()
        {
            InGamePanel.SetActive(false);
            EndPanel.SetActive(false);

            if(LevelSelectManager.LevelSelect)
            {
                LevelSelectManager.LevelSelect.RestartLevel();
            }
        }
    }
}