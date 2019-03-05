using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System;

namespace GameJam.Core
{
    public class LevelSelectManager : MonoBehaviour
    {
        public static LevelSelectManager LevelSelect { get; private set; }

        public static event Action OnLevelToMainMenu = delegate { };
        public static event Action OnLevelToInGame = delegate { };
        public static event Action OnLevelToRestart = delegate { };

        private enum Levels { mainMenu = 1, gameLevel };
        private bool isCreated = false;

        private void Awake()
        {
            if (!isCreated)
            {
                isCreated = true;
                LevelSelect = this;
                DontDestroyOnLoad(gameObject);
            }
        }

        public void ReturnToMainMenu()
        {
            OnLevelToMainMenu();
            StartCoroutine(DelayToLevelRoutine((int)Levels.mainMenu));
        }

        public void StartGameLevel()
        {
            OnLevelToInGame();
            StartCoroutine(DelayToLevelRoutine((int)Levels.gameLevel));
        }

        public void RestartLevel()
        {
            OnLevelToRestart();
            StartCoroutine(DelayToLevelRoutine((int)Levels.gameLevel));
        }

        private IEnumerator DelayToLevelRoutine(int level)
        {
            yield return new WaitForSeconds(1f);
            SceneManager.LoadScene(level);
        }
    }
}