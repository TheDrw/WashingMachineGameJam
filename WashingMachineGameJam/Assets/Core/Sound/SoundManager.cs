using System.Collections;
using UnityEngine;

namespace GameJam.Core
{
    public class SoundManager : MonoBehaviour
    {
        public static SoundManager SFX { get; private set; }
        private AudioSource audioSource;
        private bool isCreated = false;

        private void Awake()
        {
            if (!isCreated)
            {
                SFX = this;
                isCreated = true;
                audioSource = GetComponent<AudioSource>();
                DontDestroyOnLoad(gameObject);
            }
        }

        public void PlaySoundClipOneShot(AudioClip soundClip)
        {
            audioSource.PlayOneShot(soundClip);
        }

        public void PlaySoundClip(AudioClip soundClip)
        {
            audioSource.clip = soundClip;
            audioSource.Play();
        }
    }
}