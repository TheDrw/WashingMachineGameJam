using UnityEngine;
using System.Collections;

namespace GameJam.Camera
{
    [ExecuteInEditMode]
    public class TransitionsEffect : MonoBehaviour
    {
        [SerializeField] Material transitionMat;
        [SerializeField] Texture2D[] textureTransitions;
        readonly string FADE = "_Fade";
        readonly string CUTOFF = "_Cutoff";
        readonly string TEXTURE = "_TransitionTex";
        float fadeSpeed = 10f;
        float cutoffSpeed = 10f;

        private void OnEnable()
        {
            Debug.Log("TRANSITION ON ENABLE");
        }

        void OnRenderImage(RenderTexture src, RenderTexture dest)
        {
            Graphics.Blit(src, dest, transitionMat);
        }

        public void FadeOut()
        {
            StartCoroutine(FadeOutRoutine());
        }

        IEnumerator FadeOutRoutine()
        {
            transitionMat.SetFloat(CUTOFF, 1f);

            for (float start = 1f; start > 0; start -= fadeSpeed * Time.deltaTime)
            {
                transitionMat.SetFloat(FADE, start);
                yield return null;
            }
            transitionMat.SetFloat(FADE, 0f);
            this.enabled = false;
        }

        public void FadeIn()
        {
            StartCoroutine(FadeInRoutine());
        }

        IEnumerator FadeInRoutine()
        {
            transitionMat.SetFloat(CUTOFF, 1f);

            for (float start = 0f; start < 1; start += fadeSpeed * Time.deltaTime)
            {
                transitionMat.SetFloat(FADE, start);
                yield return null;
            }
            transitionMat.SetFloat(FADE, 1f);
        }

        public void CutoffOut()
        {
            StartCoroutine(CutoffOutRoutine());
        }

        IEnumerator CutoffOutRoutine()
        {
            SetRandomTransitionTexture();
            transitionMat.SetFloat(FADE, 1f);

            for (float start = 1f; start > 0; start -= cutoffSpeed * Time.deltaTime)
            {
                transitionMat.SetFloat(CUTOFF, start);
                yield return null;
            }
            transitionMat.SetFloat(CUTOFF, 0f);
            this.enabled = false;
        }

        public void CutoffIn()
        {
            StartCoroutine(CutoffInRoutine());
        }

        IEnumerator CutoffInRoutine()
        {
            SetRandomTransitionTexture();
            transitionMat.SetFloat(FADE, 1f);

            for (float start = 0f; start < 1; start += cutoffSpeed * Time.deltaTime)
            {
                transitionMat.SetFloat(CUTOFF, start);
                yield return null;
            }
            transitionMat.SetFloat(CUTOFF, 0f);
        }

        private void SetRandomTransitionTexture()
        {
            int rand = Random.Range(0, textureTransitions.Length);
            transitionMat.SetTexture(TEXTURE, textureTransitions[rand]);
        }
    }
}