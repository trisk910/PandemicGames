using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogSounds : MonoBehaviour {

    public AudioClip bark;
    public static bool barkonce = false;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

  
        if(barkonce)
        {
            GetComponent<AudioSource>().PlayOneShot(bark, 1.0f);
            barkonce = false;
        }


        if(Input.GetKeyDown(KeyCode.T))
            barkonce = true;
        
        }
}
