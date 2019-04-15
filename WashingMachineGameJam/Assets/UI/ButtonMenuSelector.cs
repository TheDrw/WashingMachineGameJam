using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using GameJam.Utility;

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

        private GameObject previousButton;

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
            ButtonHighlightChecker();
            BackButtonChecker();
        }

        private void BackButtonChecker()
        {
            if (backButton != null)
            {
                if (Input.GetButtonDown(GameConstants.CANCEL))
                {
                    backButton.onClick.Invoke();
                }
            }
        }

        // when clicking on the screen if UI is up, the eventsystem will lose focus on that gameobject
        // this will ensure if you click on screen, you will always keep focus on the gameobject.
        private void ButtonHighlightChecker()
        {
            if (EventSystem.current.currentSelectedGameObject == null)
            {
                EventSystem.current.SetSelectedGameObject(previousButton);
            }
            else
            {
                previousButton = EventSystem.current.currentSelectedGameObject;
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