using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using GameJam.Core;

namespace GameJam.UI
{
    public class IntroMessage : MonoBehaviour
    {
        [SerializeField]
        private AudioClip[] introSoundClips;

        private Text intro;

        private void Awake()
        {
            intro = GetComponent<Text>();
        }

        private void OnEnable()
        {
            StartCoroutine(MessageRoutine());
        }

        private IEnumerator MessageRoutine()
        {
            yield return new WaitForSeconds(1f);
            intro.fontSize = 50;
            intro.text = "...At a house near a bridge that's sort of golden";
            SoundManager.SFX.PlaySoundClipOneShot(introSoundClips[0]);

            yield return new WaitForSeconds(3f);
            intro.fontSize = 80;
            intro.text = "...is a house that needs to";
            SoundManager.SFX.PlaySoundClipOneShot(introSoundClips[1]);

            yield return new WaitForSeconds(3f);
            intro.fontSize = 150;
            intro.text = "TOSS";
            SoundManager.SFX.PlaySoundClipOneShot(introSoundClips[2]);

            yield return new WaitForSeconds(2f);
            intro.fontSize = 200;
            intro.text = "N'";
            SoundManager.SFX.PlaySoundClipOneShot(introSoundClips[3]);

            yield return new WaitForSeconds(1f);
            intro.text = "...";
            SoundManager.SFX.PlaySoundClipOneShot(introSoundClips[4]);

            yield return new WaitForSeconds(2f);
            intro.text = "";
            LevelSelectManager.LevelSelect.ReturnToMainMenu();
        }
    }
}