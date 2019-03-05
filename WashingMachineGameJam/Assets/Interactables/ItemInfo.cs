using UnityEngine;

namespace GameJam.Interactables
{
    [RequireComponent(typeof(ItemCollision))]
    [RequireComponent(typeof(ItemThrow))]
    public class ItemInfo : MonoBehaviour
    {
        public bool IsLaundryValid = false;
        public bool IsBeingThrown = false;
        public bool IsActive = false;
        public int Points = 0;
    }
}
