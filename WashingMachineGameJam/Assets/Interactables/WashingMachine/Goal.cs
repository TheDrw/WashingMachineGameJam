using System;
using UnityEngine;

namespace GameJam.Interactables
{
    public class Goal : MonoBehaviour
    {
        public static event Action<int> OnValidItemInGoal = delegate { };
        public static event Action<int> OnInvalidItemInGoal = delegate { };

        private void OnCollisionEnter(Collision collision)
        {
            ItemInfo itemInfo = collision.gameObject.GetComponent<ItemInfo>();
            if(itemInfo != null)
            {
                CheckItemInGoal(itemInfo);
            }
        }

        private void CheckItemInGoal(ItemInfo itemInfo)
        {
            if (itemInfo.IsLaundryValid)
            {
                OnValidItemInGoal(itemInfo.Points);
            }
            else
            {
                OnInvalidItemInGoal(itemInfo.Points);
            }
        }
    }
}