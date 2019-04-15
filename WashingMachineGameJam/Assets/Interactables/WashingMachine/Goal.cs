using System;
using UnityEngine;

namespace GameJam.Interactables
{
    public class Goal : MonoBehaviour
    {
        public static event Action<int> OnItemInGoal = delegate { };

        private void OnCollisionEnter(Collision collision)
        {
            var item = collision.gameObject.GetComponent<ICollectable>();
            if(item != null)
            {
                CheckItemInGoal(item);
            }
        }

        private void CheckItemInGoal(ICollectable item)
        {
            OnItemInGoal(item.CollectPoints);
        }
    }
}