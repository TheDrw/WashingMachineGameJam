using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// not sure if i am gonna use this
namespace GameJam.Interactables
{
    [CreateAssetMenu(menuName = "Item")]
    public class ItemConfig : ScriptableObject
    {
        [Header("Configuration")]
        [SerializeField] private GameObject itemPrefab;
        [SerializeField] private bool isLaundryValid; // don't really need it anymore, but oh well. made for initial gameplay thoughts
        [SerializeField] private int points;
        [SerializeField] private AudioClip itemGoalSound;
        [SerializeField] private AudioClip itemCollisionSound;
        [SerializeField] private AudioClip itemThrowSound;

        public GameObject ItemPrefab
        {
            get { return itemPrefab; }
        }

        public bool IsLaundryValid
        {
            get { return isLaundryValid; }
        }

        public int Points
        {
            get { return points; }
        }

        public AudioClip ItemGoalSoundClip
        {
            get { return itemGoalSound; }
        }

        public AudioClip ItemCollisionClip
        {
            get { return itemCollisionSound; }
        }

        public AudioClip ItemThrowSoundClip
        {
            get { return itemThrowSound; }
        }
    }
}