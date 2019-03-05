using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// not sure if i am gonna use this
namespace GameJam.Interactables
{
    [CreateAssetMenu(menuName = "Item")]
    public class Item : ScriptableObject
    {
        [Header("Item things")]
        [SerializeField] private GameObject itemPrefab;
        [SerializeField] private bool isLaundryValid;
        [SerializeField] private int points;
        [SerializeField] private AudioClip itemSound;

        private void OnEnable()
        {
            var itemInfo = itemPrefab.GetComponent<ItemInfo>();
            itemInfo.IsLaundryValid = isLaundryValid;
            itemInfo.Points = points;
        }

        public GameObject GetItemPrefab()
        {
            return itemPrefab;
        }

        public AudioClip GetSoundClip()
        {
            return null;
        }
    }
}