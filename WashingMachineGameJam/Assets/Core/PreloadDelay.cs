using UnityEngine;
using System.Collections;

// To load in the DontDestroyOnLoad object things. Most likely not ncessary.
namespace GameJam.Useless
{
    public class PreloadDelay : MonoBehaviour
    {
        private void OnEnable()
        {
            StartCoroutine(DelayRoutine());
        }

        private IEnumerator DelayRoutine()
        {
            yield return new WaitForSeconds(2f);
            Core.LevelSelectManager.LevelSelect.ReturnToMainMenu();
        }
    }
}