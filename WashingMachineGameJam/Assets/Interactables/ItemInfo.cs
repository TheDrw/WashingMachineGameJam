using UnityEngine;
using GameJam.Core;

namespace GameJam.Interactables
{
    [RequireComponent(typeof(ItemCollision))]
    [RequireComponent(typeof(ItemThrow))]
    public class ItemInfo : MonoBehaviour
    {
        [SerializeField]
        private ItemConfig itemConfig;
        
        public bool IsBeingThrown { get; set; }
        public bool IsActive { get; set; }

        public int Points { get { return itemConfig.Points; } }
        public bool IsLaundryValid { get { return itemConfig.IsLaundryValid; } }

        private void Awake()
        {
            Init();
        }

        private void Init()
        {
            IsBeingThrown = false;
            IsActive = false;
        }

        public void PlayGoalSound()
        {
            if(!SoundManager.SFX) return;
            SoundManager.SFX.PlaySoundClipOneShot(itemConfig.ItemGoalSoundClip);
        }

        public void PlayThrowSound()
        {
            if (!SoundManager.SFX) return;
            SoundManager.SFX.PlaySoundClipOneShot(itemConfig.ItemThrowSoundClip);
        }

        public void PlayCollisionSound()
        {
            if (!SoundManager.SFX) return;
            SoundManager.SFX.PlaySoundClip(itemConfig.ItemCollisionClip);
        }
    }
}
