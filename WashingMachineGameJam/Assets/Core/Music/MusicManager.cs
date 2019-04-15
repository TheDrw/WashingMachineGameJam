using UnityEngine;
using System.Collections;
using GameJam.Utility;

namespace GameJam.Core
{
    public class MusicManager : MonoBehaviour
    {
        public static MusicManager Music { get; private set; }
        

        [SerializeField]
        private AudioClip mainMenu;

        [SerializeField]
        private AudioClip inGame;

        private bool isCreated = false;
        private AudioSource audioSource;

        private void Awake()
        {
            if (!isCreated)
            {
                isCreated = true;
                Music = this;
                audioSource = GetComponent<AudioSource>();
                audioSource.loop = true;
                DontDestroyOnLoad(gameObject);
            }
        }

        private void OnEnable()
        {
            LevelSelectManager.OnLevelToMainMenu += PlayMainMenuMusic;
            LevelSelectManager.OnLevelToInGame += PlayInGameMusic;
        }

        private void OnDisable()
        {
            LevelSelectManager.OnLevelToMainMenu -= PlayMainMenuMusic;
            LevelSelectManager.OnLevelToInGame -= PlayInGameMusic;
        }

        private void PlayMainMenuMusic()
        {

            StopAllCoroutines();
            audioSource.Stop();
            audioSource.clip = mainMenu;
            StartCoroutine(DelayMusicRoutine(1));
        }

        private void PlayInGameMusic()
        {
            StopAllCoroutines();
            audioSource.Stop();
            // play
            // delay
        }



        private IEnumerator DelayMusicRoutine(float delay = 0f)
        {
            yield return new WaitForSeconds(delay);
            audioSource.Play();
        }
    }
}