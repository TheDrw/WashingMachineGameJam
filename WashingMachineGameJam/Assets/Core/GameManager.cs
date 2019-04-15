using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameJam.Core
{
    public class GameManager : MonoBehaviour
    {
        private void Awake()
        {
            DontDestroyOnLoad(gameObject);
        }

        void Start()
        {
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.lockState = CursorLockMode.Locked;
            //Cursor.lockState = CursorLockMode.None;
            Cursor.visible = false;

            //Application.targetFrameRate = -1;
        }

    }
}
