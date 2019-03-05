using UnityEngine;
using GameJam.Core;

namespace GameJam.Camera
{
    public class TransitionManager : MonoBehaviour
    {
        TransitionsEffect transitionEffect;

        private void Awake()
        {
            transitionEffect = GetComponent<TransitionsEffect>();
            transitionEffect.enabled = false;

            LevelSelectManager.OnLevelToMainMenu += FadeInTransition;
            LevelSelectManager.OnLevelToInGame += FadeInTransition;
            LevelSelectManager.OnLevelToRestart += FadeInTransition;
        }

        private void Start()
        {
            int rand = Random.Range(0, 4);

            if (rand == 0)
                FadeOutTransition();
            else
                CutoffOutTransition();
        }

        private void OnDisable()
        {
            LevelSelectManager.OnLevelToMainMenu -= FadeInTransition;
            LevelSelectManager.OnLevelToInGame -= FadeInTransition;
            LevelSelectManager.OnLevelToRestart -= FadeInTransition;
        }

        private void FadeOutTransition()
        {
            Debug.Log("FadeOIut");
            transitionEffect.enabled = true;
            transitionEffect.FadeOut();
        }

        private void FadeInTransition()
        {
            Debug.Log("FadeIn");
            transitionEffect.enabled = true;
            transitionEffect.FadeIn();
        }

        private void CutoffOutTransition()
        {
            Debug.Log("CutoffOut");
            transitionEffect.enabled = true;
            transitionEffect.CutoffOut();
        }

        private void CutoffInTransition()
        {
            Debug.Log("CutoffIn");
            transitionEffect.enabled = true;
            transitionEffect.CutoffIn();
        }
    }
}