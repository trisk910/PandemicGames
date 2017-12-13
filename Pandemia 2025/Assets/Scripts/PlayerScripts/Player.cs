using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public float playerSpeed;
    public float playerRotation;
    private Dog DogFunctions;

    //puertas
    private GameObject Ph7;
    private GameObject Ph6;
    private GameObject Ph5;
    private GameObject Ph4;
    private GameObject Ph3;
    private GameObject Ph2;
    private GameObject Ph1;

    private GameObject th7;
    private GameObject th6;
    private GameObject th5;
    private GameObject th4;
    private GameObject th3;
    private GameObject th1;

    public GameObject Key;
    private GameObject cKey;

    public GameObject textCode;
    //Bolean Puertas
    private bool OpenPh2 = false;


    // Use this for initialization
    void Start()
    {
        Ph7 = (GameObject)GameObject.FindGameObjectWithTag("Ph7");
        Ph6 = (GameObject)GameObject.FindGameObjectWithTag("Ph6");
        Ph5 = (GameObject)GameObject.FindGameObjectWithTag("Ph5");
        Ph4 = (GameObject)GameObject.FindGameObjectWithTag("Ph4");
        Ph3 = (GameObject)GameObject.FindGameObjectWithTag("Ph3");
        Ph2 = (GameObject)GameObject.FindGameObjectWithTag("Ph2");
        Ph1 = (GameObject)GameObject.FindGameObjectWithTag("Ph1");

        th7 = (GameObject)GameObject.FindGameObjectWithTag("Th7");
        th6 = (GameObject)GameObject.FindGameObjectWithTag("Th6");
        th5 = (GameObject)GameObject.FindGameObjectWithTag("Th5");
        th4 = (GameObject)GameObject.FindGameObjectWithTag("Th4");
        th3 = (GameObject)GameObject.FindGameObjectWithTag("Th3");
        th1 = (GameObject)GameObject.FindGameObjectWithTag("Th1");

        DogFunctions = FindObjectOfType<Dog>();

    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
        CallDogToSearch();      

    }

    void MovePlayer()
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

    void CallDogToSearch()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if(Dog.isRoom5==true)
            {
                Dog.search = true;
               
            }
        }
    }
    private void OnCollisionEnter(Collision collision)
    {

        //OpeningDoors
        if (collision.gameObject.tag == "Ph7")
        {
            //Ph6.GetComponent<Animation>().Play();
            if (GameManager.Instance.haveKeyFromRoom5)
            {
                Ph7.gameObject.transform.rotation = Quaternion.Euler(new Vector3(transform.rotation.x, -90.0f, transform.position.y));
                GameManager.Instance.canOpenDoorH1 = true;
                Destroy(th7.gameObject);
            }
        }
        if (collision.gameObject.tag == "Ph6")
        {
            Ph6.gameObject.transform.rotation = Quaternion.Euler(new Vector3(transform.rotation.x, -90.0f, transform.position.y));
            Destroy(th6.gameObject);
        }

        if (collision.gameObject.tag == "Ph5")
        {
            Ph5.gameObject.transform.rotation = Quaternion.Euler(new Vector3(transform.rotation.x, -90.0f, transform.rotation.y));
            Destroy(th5.gameObject);
        }

        if (collision.gameObject.tag == "Ph4")
        {
            Ph4.gameObject.transform.rotation = Quaternion.Euler(new Vector3(transform.rotation.x, -90.0f, transform.position.y));
            Destroy(th4);
        }

        if (collision.gameObject.tag == "Ph3")
        {
            Ph3.gameObject.transform.rotation = Quaternion.Euler(new Vector3(transform.rotation.x, 0.0f, transform.position.y));
            Destroy(th3.gameObject);
        }

        if (collision.gameObject.tag == "Ph2")
            if (OpenPh2)
                Ph2.gameObject.transform.rotation = Quaternion.Euler(new Vector3(transform.rotation.x, 0.0f, transform.position.y));

        if (collision.gameObject.tag == "Ph1")
        {
            if (GameManager.Instance.canOpenDoorH1)
            { 
                Ph1.gameObject.transform.rotation = Quaternion.Euler(new Vector3(transform.rotation.x, 0.0f, transform.position.y));
                Destroy(th1.gameObject);
            }
        }

        if (collision.gameObject.tag == "BatteriaH1")
        {
            GameManager.Instance.haveTheBaterieFromRoom1 = true;
            Destroy(collision.gameObject);

        }

        if (collision.gameObject.tag == "putBatteria")
        {
            if (GameManager.Instance.haveTheBaterieFromRoom1)
            { 
                GameManager.Instance.showBatteriaInRoom5 = true;
                
            }
            
        }
        if(collision.gameObject.tag == "ElevatorDoors")
        {
            GameManager.Instance.LoadLevels();
        }


    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "TriggerH4Code")
        {
            GameManager.Instance.havePassword = true;
            
            Destroy(textCode.gameObject);
        }

        if(other.gameObject.tag == "IntroducePass")
        {
            GameManager.Instance.showHavePass = true;
        }

    }
}