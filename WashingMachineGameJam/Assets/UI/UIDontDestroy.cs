using UnityEngine;

public class UIDontDestroy : MonoBehaviour
{
    private bool isCreated = false;
    private void Awake()
    {
        if(!isCreated)
        {
            isCreated = true;
            DontDestroyOnLoad(gameObject);
        }
    }
}
