using UnityEngine;

namespace GameJam.Core
{
    // This is no longer a camera controller, but more of an object rotator.
    // childed to it is a game object in which the CCTV camera follows that game object.
    // This rotates the child so the CCTV can follow it.
    public class ObjectRotator : MonoBehaviour
    {
        public static ObjectRotator main;

        [SerializeField]
        private Vector2 maxRotation;

        [SerializeField]
        [Range(0.1f, 5f)]
        private float rotationSpeed = 0.5f;

        private Vector2 rotation = Vector2.zero;
        private Vector3 followVelocity;

        private readonly string MOUSE_X = "Mouse X";
        private readonly string MOUSE_Y = "Mouse Y";

        private void Awake()
        {
            if (main == null)
            {
                main = this;
            }

            Cursor.lockState = CursorLockMode.Confined;
            Cursor.lockState = CursorLockMode.Locked;
            //Cursor.lockState = CursorLockMode.None;
            Cursor.visible = false;
        }

        private void Update()
        {
            rotation.y += Input.GetAxis(MOUSE_X);
            rotation.x += -1f * Input.GetAxis(MOUSE_Y);

            rotation.x = Mathf.Clamp(rotation.x, -maxRotation.y, maxRotation.y);
            rotation.y = Mathf.Clamp(rotation.y, -maxRotation.x, maxRotation.x);
            transform.eulerAngles = rotation * rotationSpeed;
        }
    }
}