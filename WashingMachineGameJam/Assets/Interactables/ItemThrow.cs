using System.Collections;
using UnityEngine;

namespace GameJam.Interactables
{
    [RequireComponent(typeof(Rigidbody))]
    public class ItemThrow : MonoBehaviour, IThrowable
    {
        private ItemInfo itemInfo;
        private Rigidbody itemRigidbody;

        public void Awake()
        {
            itemInfo = GetComponent<ItemInfo>();
            itemRigidbody = GetComponent<Rigidbody>();
            itemRigidbody.angularDrag = 0.0f;
            itemRigidbody.useGravity = false;
        }

        private void OnEnable()
        {
            ResetItem();
        }

        private void OnDisable()
        {
            ResetItem();
        }

        public void FirstFrameHold()
        {
            //ResetItem();
            itemInfo.IsActive = true;
        }

        public void ResetItem()
        {
            itemRigidbody.velocity = Vector3.zero;
            itemRigidbody.angularVelocity = Vector3.zero;
            itemRigidbody.useGravity = false;
            itemInfo.IsBeingThrown = false;
            itemInfo.IsActive = false;
        }

        // TODO - Jittering when holding object. 
        // Must be something with this function or how the function is being called.
        // Probably will never fix it.
        public void Holding(Vector3 pickupPosition)
        {
            //itemRigidbody.MovePosition(pickupPosition);
            //transform.localPosition = pickupPosition;
            //itemRigidbody.position = Vector3.Lerp(transform.localPosition, pickupPosition, 0.9f);
            transform.position = Vector3.Lerp(transform.localPosition, pickupPosition, 0.9f);
        }

        public void Throw(Vector3 throwDirection, Vector3 forwardDirection)
        {
            itemRigidbody.useGravity = true;
            itemRigidbody.AddForce(throwDirection, ForceMode.Impulse);
            itemRigidbody.AddForce(forwardDirection, ForceMode.Impulse);
            StartCoroutine(ItemLifetimeInGameRoutine());
            itemInfo.IsBeingThrown = true;
            itemInfo.PlayThrowSound();
        }

        //private void InactivateItem()
        //{
        //    itemInfo.IsActive = false;
        //    itemInfo.IsBeingThrown = false;
        //    StopAllCoroutines();
        //    gameObject.SetActive(false);
        //}

        // in case if the item is stuck somewhere or doesn't go away when colliding with something, this will turn it off after some seconds.
        private IEnumerator ItemLifetimeInGameRoutine()
        {
            const float MAXIMUM_LIFETIME_IN_SECONDS = 3f;
            yield return new WaitForSeconds(MAXIMUM_LIFETIME_IN_SECONDS);

            if (gameObject.activeSelf)
            {
                gameObject.SetActive(false);
            }
        }
    }
}