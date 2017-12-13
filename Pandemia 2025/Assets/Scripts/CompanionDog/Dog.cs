using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dog : MonoBehaviour {

    private GameObject Player;

    public float movSpeed;
    public float rotSpeed;

    private Transform dPos;
    private Transform target;

    private bool follow = true;

    private void Awake()
    {
        dPos = transform;
    }
    // Use this for initialization
    void Start() {

        Player = (GameObject)GameObject.FindGameObjectWithTag("Player");

        target = Player.transform;
    }

    // Update is called once per frame
    void Update() {
        

      


        if (follow == true)
        {
            dPos.rotation = Quaternion.Slerp(dPos.rotation, Quaternion.LookRotation(target.position - dPos.position), rotSpeed * Time.deltaTime);
            dPos.position += dPos.forward * movSpeed * Time.deltaTime;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
            follow = false;
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
            follow = true;

    }
}
