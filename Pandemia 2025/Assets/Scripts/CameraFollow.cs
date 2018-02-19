using UnityEngine;
using System.Collections;

namespace CompleteProject
{
    public class CameraFollow : MonoBehaviour
    {
        public Transform target;            // The position that that camera will be following.
        public float smoothing = 5f;        // The speed with which the camera will be following.

        private Dog DogFunctions;

        private GameObject Player;
        private GameObject Doggy;


        Vector3 offset;                     // The initial offset from the target.


        void Start ()
        {
            // Calculate the initial offset.
            offset = transform.position - target.position;

            Player = (GameObject)GameObject.FindGameObjectWithTag("Player");
            Doggy = (GameObject)GameObject.FindGameObjectWithTag("Dog");

            DogFunctions = FindObjectOfType<Dog>();
        }


        void Update ()
        {
            // Create a postion the camera is aiming for based on the offset from the target.
            Vector3 targetCamPos = target.position + offset;

            // Smoothly interpolate between the camera's current position and it's target position.
            transform.position = Vector3.Lerp (transform.position, targetCamPos, smoothing * Time.deltaTime);

            SwitchCharacter();
        }

        void SwitchCharacter()
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                Dog.isControlled = false;
                Input.ResetInputAxes();
                target = Player.gameObject.transform;
                GameManager.Instance.switchCharacter = false;
            }

            if (Input.GetKeyDown(KeyCode.T))
            {
                Dog.isControlled = true;
                Input.ResetInputAxes();
                target = Doggy.gameObject.transform;
                GameManager.Instance.switchCharacter = true;
            }
        }
    }
}