using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PasswordShow : MonoBehaviour {


    
	// Use this for initialization
	void Start () {

        this.gameObject.GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {

        gameObject.GetComponent<Text>().text = GameManager.Instance.randomPassword.ToString();
    }
}
