using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dog : MonoBehaviour {

    private GameObject Player;
    private GameObject mueble1;
    private GameObject mueble2;
    private GameObject muebleLlave;

    public float movSpeed;
    public float rotSpeed;

    private Transform dPos;
    private Transform target;

    public static bool stopFollow = false;
    private bool follow;
    public static bool search;

    public static bool isRoom5 = false;
    private float searchTimer;

    public GameObject key;
    private GameObject cKey;
    private float force = 300.0f;

    private void Awake()
    {
        dPos = transform;
    }
    // Use this for initialization
    void Start() {

        Player = (GameObject)GameObject.FindGameObjectWithTag("Player");
        mueble1 = (GameObject)GameObject.FindGameObjectWithTag("Mueble1");
        mueble2 = (GameObject)GameObject.FindGameObjectWithTag("Mueble2");
        muebleLlave  = (GameObject)GameObject.FindGameObjectWithTag("MuebleConLlave");

        search = false;
        follow = true;
        searchTimer = 0.0f;
        stopFollow = false;

        target = Player.transform;
    }

    // Update is called once per frame
    void Update()
    {
        if(!stopFollow)
            target = Player.transform;

        //Debug.Log(searchTimer + " Time");

        if (follow == true)
        {
            dPos.rotation = Quaternion.Slerp(dPos.rotation, Quaternion.LookRotation(target.position - dPos.position), rotSpeed * Time.deltaTime);
            dPos.position += dPos.forward * movSpeed * Time.deltaTime;
        }

        if (stopFollow)
        {
            dPos.rotation = Quaternion.Slerp(dPos.rotation, Quaternion.LookRotation(target.position - dPos.position), rotSpeed * Time.deltaTime);
            dPos.position += dPos.forward * movSpeed * Time.deltaTime;
        }

        SearchForItems();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            follow = false;
        }

        if (other.gameObject.tag == "TriggerH5")
            isRoom5 = true;

            
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            
                follow = true;
        }

        if (other.gameObject.tag == "TriggerH5")
            isRoom5 = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        
    }

    public void SearchForItems()
    {
        if (search)
        {
            stopFollow = true;

            searchTimer += Time.fixedDeltaTime;

            if (isRoom5)
            { 

            if (searchTimer >= 0.0f)
                target = mueble1.transform;

            if (searchTimer >= 6.0f)
                target = mueble2.transform;

            if (searchTimer >= 11.0f)
                target = muebleLlave.transform;

            if (searchTimer >= 16.0f)
            {
                GameManager.Instance.haveKeyFromRoom5 = true;
                    cKey = Instantiate(key);
                    cKey.gameObject.GetComponent<Rigidbody>().AddForce(transform.up * force);
                    Physics.IgnoreCollision(cKey.GetComponent<Collider>(), this.GetComponent<Collider>());
                    Destroy(cKey, 2.0f);
                    Start();
            }
         }    
        }

    }

}
