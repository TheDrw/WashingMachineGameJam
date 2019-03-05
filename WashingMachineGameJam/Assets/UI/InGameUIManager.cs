using UnityEngine;
using GameJam.GameConstants;
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

        private bool isGameActive;

        private void Start()
        {
            Countdown.OnGameStart += GameStart;
            Timer.OnGameFinished += GameEnd;
        }

        private void Update()
        {
            if (!isGameActive) return;

            if(Input.GetButtonDown(Constants.CANCEL))
            {
                if (!PausePanel.activeSelf)
                {
                    PausePanel.SetActive(true);
                }
            }
        }

        private void OnDisable()
        {
            Countdown.OnGameStart -= GameStart;
            Timer.OnGameFinished -= GameEnd;
        }

        private void GameStart()
        {
            isGameActive = true;
        }

        private void GameEnd()
        {
            isGameActive = false;
            StartCoroutine(DelayEndPanel());
        }

        IEnumerator DelayEndPanel()
        {
            yield return new WaitForSeconds(2f);
            EndPanel.SetActive(true);
        }

        public void ReturnToGame()
        {
            PausePanel.SetActive(false);
        }

        public void ReturnToMainMenu()
        {
            PausePanel.SetActive(false);
            EndPanel.SetActive(false);
            LevelSelectManager.LevelSelect.ReturnToMainMenu();   
        }

        public void Retry()
        {
            EndPanel.SetActive(false);
            LevelSelectManager.LevelSelect.RestartLevel();
        }
    }
}