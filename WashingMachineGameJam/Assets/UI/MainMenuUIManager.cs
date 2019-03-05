using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameJam.Core;

namespace GameJam.UI
{
    public class MainMenuUIManager : MonoBehaviour
    {
        [SerializeField]
        private GameObject frontMenuPanel;

        [SerializeField]
        private GameObject creditsPanel;

        [SerializeField]
        private GameObject exitPanel;

        private void OnEnable()
        {
            frontMenuPanel.SetActive(false);
            creditsPanel.SetActive(false);
            exitPanel.SetActive(false);

            StartCoroutine(ShowFrontMenuDelayRoutine());
        }

        private IEnumerator ShowFrontMenuDelayRoutine()
        {
            yield return new WaitForSeconds(3f);
            frontMenuPanel.SetActive(true);
        }

        public void PlayGame()
        {
            LevelSelectManager.LevelSelect.StartGameLevel();

            frontMenuPanel.SetActive(false);
            creditsPanel.SetActive(false);
            exitPanel.SetActive(false);
        }

        public void ShowExitPanel()
        {
            frontMenuPanel.SetActive(false);
            exitPanel.SetActive(true);
        }

        public void ExitPanelToMainMenu()
        {
            exitPanel.SetActive(false);
            frontMenuPanel.SetActive(true);
        }

        public void ShowCreditsPanel()
        {
            frontMenuPanel.SetActive(false);
            creditsPanel.SetActive(true);
        }

        public void CreditsPanelToMainMenu()
        {
            frontMenuPanel.SetActive(true);
            creditsPanel.SetActive(false);
        }

        public void TurnOffGame()
        {
            Application.Quit();
        }

    }
}