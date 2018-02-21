using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayButtom : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnMouseDown()
    {
        Application.LoadLevel(1);
    }
}
