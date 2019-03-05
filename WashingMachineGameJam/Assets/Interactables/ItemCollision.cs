using UnityEngine;

namespace GameJam.Interactables
{
    public class ItemCollision : MonoBehaviour
    {
        private ItemInfo itemInfo;

        private void Awake()
        {
            itemInfo = GetComponent<ItemInfo>();
        }

        private void OnCollisionEnter(Collision collision)
        {
            if(itemInfo.IsBeingThrown)
            {
                var goal = collision.gameObject.GetComponent<Goal>();
                if(goal != null)
                {
                    gameObject.SetActive(false);
                }
            }
        }
    }
}