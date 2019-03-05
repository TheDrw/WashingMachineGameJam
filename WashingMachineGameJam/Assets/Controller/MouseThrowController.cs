using UnityEngine;
using GameJam.Interactables;
using GameJam.Camera;
using GameJam.UI;

namespace GameJam.Controller
{
    public class MouseThrowController : MonoBehaviour
    {
        [SerializeField]
        private Transform pickupPosition;

        [SerializeField]
        private Vector3 throwSpeed = new Vector3(2f, 5f, 2.5f);

        private Vector3 prev;
        private ItemsPool itemsPool;
        private ItemThrow itemThrow;
        private Item item;
        private bool isHolding = false;
        private bool isGameActive = false;

        private void Awake()
        {
            Application.targetFrameRate = 144;   
        }

        private void Start()
        {
            if (pickupPosition == null)
            {
                Debug.LogError("Pickup position is missing - it is located as child on the camera.");
            }

            itemsPool = FindObjectOfType<ItemsPool>();
            if (itemsPool == null)
            {
                Debug.LogError("Items pool not found in scene.");
            }

            Countdown.OnGameStart += UnlockControls;
            Timer.OnGameFinished += LockControls;
        }

        private void Update()
        {
            if (!isGameActive)
            {
                return;
            }

            if (Input.GetMouseButtonDown(0) && !isHolding)
            {
                Grab();
            }
            else if (Input.GetMouseButton(0) && isHolding)
            {
                Hold();
            }
            else if (Input.GetMouseButtonUp(0) && isHolding)
            {
                Throw();
            }
        }

        private void OnDisable()
        {
            Countdown.OnGameStart -= UnlockControls;
            Timer.OnGameFinished -= LockControls;
        }

        // I really don't like this, but I only have 5 hours left on this game jam
        // and I've been awake for 24 hours.
        // I think I am dying.
        private void UnlockControls()
        {
            isGameActive = true;
        }

        private void LockControls()
        {
            isGameActive = false;
        }

        private void Grab()
        {
            var go = itemsPool.GetItemFromPool();
            if (go != null)
            {
                itemThrow = go.GetComponent<ItemThrow>();
                isHolding = true;
            }
        }

        private void Hold()
        {
            if (itemThrow != null)
            {
                prev = pickupPosition.transform.position;
                itemThrow.Holding(pickupPosition.position);
            }
        }

        // throwing closely mimic's how it is in the real world in this game. But isn't supposed to.
        // throwing an object is calcluated in the x-y plane for the direction where it is will go. 
        // then calculate the 'fwd' in terms of where the camera is facing. the fwd throw is dependent 
        // on how fast the player has dragged the mouse. But having a large range for the magnitude 
        // makes the throw inconsistent and hard to determine how to throw. So it is clamped btwn [0,1].
        // this is designed so even the slightest flick will throw the object at a decent range.
        private void Throw()
        {
            if (itemThrow != null)
            {
                // because unity truncates small numbers past a certain decimal pt when doing calculations, you have to multiply it to get those numbers.
                // had a really annoying issue that would just give me zero everytime when calculating its direction
                const float FLOAT_MAGNIFIER = 10000f;
                Vector2 throwDirection = prev * FLOAT_MAGNIFIER - pickupPosition.transform.position * FLOAT_MAGNIFIER;
                float dragMagnitude = Mathf.Clamp(throwDirection.magnitude, 0f, 1f);

                throwDirection = throwDirection.normalized;

                Vector3 throwDragDirectionForce = new Vector3(-1f * throwDirection.x * throwSpeed.x, -1f * throwDirection.y * throwSpeed.y, 0f);
                Vector3 fwd = CameraController.main.transform.position - pickupPosition.transform.position;
                Vector3 throwFacingForwardDirecitonForce = -1f * fwd * throwSpeed.z * dragMagnitude;

                itemThrow.Throw(throwDragDirectionForce, throwFacingForwardDirecitonForce);
                isHolding = false;
            }
        }


    }
}