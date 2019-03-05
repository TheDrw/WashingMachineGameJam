using System.Collections;
using UnityEngine;

namespace GameJam.Core
{
    public class SoundManager : MonoBehaviour
    {
        public static SoundManager SFX { get; private set; }
        private bool isCreated = false;

        private void Awake()
        {
            if (!isCreated)
            {
                isCreated = true;
                SFX = this;
                DontDestroyOnLoad(gameObject);
            }
        }
    }
}