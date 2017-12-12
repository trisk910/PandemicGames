using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public float playerSpeed;
    public float playerRotation;
    

    // Use this for initialization
    void Start()
    {
        

    }

    // Update is called once per frame
    void Update()
    {
        movePlayer();

       

    }

    void movePlayer()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.forward * playerSpeed * Time.deltaTime);
            gameObject.GetComponent<Animation>().Play("run");
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.back * playerSpeed * Time.deltaTime);
            gameObject.GetComponent<Animation>().Play("run");
        }
        else if(Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.W))
            gameObject.GetComponent<Animation>().Play("idle");

        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(new Vector3 (0, playerRotation * Time.deltaTime, 0));

        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(new Vector3(0, - playerRotation * Time.deltaTime, 0));

        }
    }
}