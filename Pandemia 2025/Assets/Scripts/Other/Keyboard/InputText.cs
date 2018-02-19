using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputText : MonoBehaviour {

    public static string currentPassword = "";

    private int max = 4;
    public static bool s0 = false;
    public static bool s1 = false;
    public static bool s2 = false;
    public static bool s3 = false;
    public static bool s4 = false;
    public static bool s5 = false;
    public static bool s6 = false;
    public static bool s7 = false;
    public static bool s8 = false;
    public static bool s9 = false;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {


        this.gameObject.GetComponent<Text>().text = currentPassword;

        if(currentPassword.Length>max)
        {
            currentPassword = "";
        }

        if(s0)
        {
            currentPassword += "0";
            s0 = false;
        }
        if (s1)
        {
            currentPassword += "1";
            s1 = false;
        }
        if (s2)
        {
            currentPassword += "2";
            s2 = false;
        }
        if (s3)
        {
            currentPassword += "3";
            s3 = false;
        }
        if (s4)
        {
            currentPassword += "4";
            s4 = false;
        }
        if (s5)
        {
            currentPassword += "5";
            s5 = false;
        }
        if (s6)
        {
            currentPassword += "6";
            s6 = false;
        }
        if (s7)
        {
            currentPassword += "7";
            s7 = false;
        }
        if (s8)
        {
            currentPassword += "8";
            s8 = false;
        }
        if (s9)
        {
            currentPassword += "9";
            s9 = false;
        }


    }
}
