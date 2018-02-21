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

        private GameObject johnSelect;
        private GameObject johnNotSelect;
        private GameObject dogSelect;
        private GameObject dogNotSelect;
        private bool johnselected = true;
        private bool dogselected = false;


        Vector3 offset;                     // The initial offset from the target.


        void Start ()
        {
            // Calculate the initial offset.
            offset = transform.position - target.position;

            Player = (GameObject)GameObject.FindGameObjectWithTag("Player");
            Doggy = (GameObject)GameObject.FindGameObjectWithTag("Dog");

            johnSelect = (GameObject)GameObject.FindGameObjectWithTag("GuiJohnSelected");
            johnNotSelect = (GameObject)GameObject.FindGameObjectWithTag("GuiJohnNotSelected");
            dogSelect = (GameObject)GameObject.FindGameObjectWithTag("GuiDogSelected");
            dogNotSelect = (GameObject)GameObject.FindGameObjectWithTag("GuiDogNotSelected");


            DogFunctions = FindObjectOfType<Dog>();
        }


        void Update ()
        {
            // Create a postion the camera is aiming for based on the offset from the target.
            Vector3 targetCamPos = target.position + offset;

            // Smoothly interpolate between the camera's current position and it's target position.
            transform.position = Vector3.Lerp (transform.position, targetCamPos, smoothing * Time.deltaTime);

            SwitchCharacter();


            if(johnselected)
            {
                johnSelect.SetActive(true);
                johnNotSelect.SetActive(false);
                dogSelect.SetActive(false);
                dogNotSelect.SetActive(true);
            }
            if(dogselected)
            {
                johnSelect.SetActive(false);
                johnNotSelect.SetActive(true);
                dogSelect.SetActive(true);
                dogNotSelect.SetActive(false);
            }
        }

        void SwitchCharacter()
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                Dog.isControlled = false;
                johnselected = true;
                dogselected = false;
                Input.ResetInputAxes();
                target = Player.gameObject.transform;
                GameManager.Instance.switchCharacter = false;
            }

            if (Input.GetKeyDown(KeyCode.T))
            {
               
                Dog.isControlled = true;
                johnselected = false;
                dogselected = true;
                Input.ResetInputAxes();
                target = Doggy.gameObject.transform;
                GameManager.Instance.switchCharacter = true;
            }
        }
    }
}