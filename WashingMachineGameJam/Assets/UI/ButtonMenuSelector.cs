using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using GameJam.GameConstants;


namespace GameJam.UI
{
    public class ButtonMenuSelector : MonoBehaviour
    {
        [SerializeField]
        private EventSystem eventSystem;

        [SerializeField]
        private GameObject highlightThisButton;

        [SerializeField]
        private Button backButton;

        private void Start()
        {
            if(eventSystem == null)
            {
                eventSystem = FindObjectOfType<EventSystem>();
            }
        }

        private void OnEnable()
        {
            StartCoroutine(WaitEndFrameRoutine());
        }

        private void Update()
        {
            if(backButton != null)
            {
                if(Input.GetButtonDown(Constants.CANCEL))
                {
                    backButton.onClick.Invoke();
                }
            }
        }

        // fixes the bug where the highlighted button doesn't get selected/highlighted. wait end of frame gets rid of it
        private IEnumerator WaitEndFrameRoutine()
        {
            yield return new WaitForEndOfFrame();
            eventSystem.SetSelectedGameObject(null);
            eventSystem.SetSelectedGameObject(highlightThisButton);
        }



    }
}