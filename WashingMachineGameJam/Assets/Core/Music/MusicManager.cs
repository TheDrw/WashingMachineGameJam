using UnityEngine;
using System.Collections;

namespace GameJam.Core
{
    public class MusicManager : MonoBehaviour
    {
        public static MusicManager Music { get; private set; }
        private bool isCreated = false;

        private void Awake()
        {
            if (!isCreated)
            {
                isCreated = true;
                Music = this;
                DontDestroyOnLoad(gameObject);
            }
        }
    }
}