using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaterieMove : MonoBehaviour {

    private float speed = 0.2f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        transform.position = new Vector3(transform.position.x, Mathf.PingPong(speed*Time.time, 0.3f)+1.0f, transform.position.z);
    }
}
