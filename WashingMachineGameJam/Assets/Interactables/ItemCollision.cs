using UnityEngine;

namespace GameJam.Interactables
{
    public class ItemCollision : MonoBehaviour, ICollectable
    {
        private ItemInfo itemInfo;
        public int CollectPoints { get { return itemInfo.Points; } }

        private void Awake()
        {
            itemInfo = GetComponent<ItemInfo>();
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (itemInfo.IsBeingThrown)
            {
                var goal = collision.gameObject.GetComponent<Goal>();
                if (goal != null)
                {
                    itemInfo.PlayGoalSound();
                    gameObject.SetActive(false);
                }
                else if(collision.relativeVelocity.magnitude > 1f) // gets rid of incremental collisions producing sounds
                {
                    itemInfo.PlayCollisionSound();
                }
            }
        }
    }
}