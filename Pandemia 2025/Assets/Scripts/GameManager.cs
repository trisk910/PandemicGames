using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public static GameManager Instance;

    public bool switchCharacter = false;

    private GameObject[] LightTextures;

    public bool haveKeyFromRoom5 = false;
    public bool haveTheBaterieFromRoom1 = false;
    public bool havePassword = false;
    public bool showHavePass = false;

    public bool canOpenDoorH1 = false;

    private GameObject BatteriaInRoom5;
    public bool showBatteriaInRoom5 =false;
    

    public GameObject askPass;
    public GameObject showPassF;
    public bool canGoGetCode = false;

    public GameObject IntroducePassT;

    public GameObject light;

    public bool respawnKey = true;
    

    private bool canGoElevator = false;

    private GameObject Lights;


    private Dog DogFunctions;



    private GameObject Keyboard;
    public bool showKeyboard = false;
    public string password = "";
   
    public float randomPassword;
   
    private float min = 0, max = 9;

    //GUI
    private GameObject showGuiBateria;
    private GameObject showGuiKey;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;

        }

    }

    // Use this for initialization
    void Start () {

        Keyboard = (GameObject)GameObject.FindGameObjectWithTag("showKeyboard");

        showGuiBateria = (GameObject)GameObject.FindGameObjectWithTag("ShowGuiBateria");
        showGuiKey = (GameObject)GameObject.FindGameObjectWithTag("ShowGuiKey");


        LightTextures = GameObject.FindGameObjectsWithTag("lightsOn");

        foreach (GameObject LightTexture in LightTextures)
        {
            LightTexture.SetActive(false);
        }

            showGuiBateria.SetActive(false);
        showGuiKey.SetActive(false);

        makePassword();

        Keyboard.SetActive(false);

      

        BatteriaInRoom5 = (GameObject)GameObject.FindGameObjectWithTag("BatteriaH5");

        Lights = (GameObject)GameObject.FindGameObjectWithTag("Lights");

        BatteriaInRoom5.SetActive(false);

        askPass.SetActive(false);
       // showPassF.SetActive(false);
       // IntroducePassT.SetActive(false);

        light.GetComponent<Light>().intensity = 0;
        Lights.gameObject.SetActive(false);

        DogFunctions = FindObjectOfType<Dog>();
    }
	
	// Update is called once per frame
	void Update () {

        //GUI bool

        if (haveTheBaterieFromRoom1)
            showGuiBateria.SetActive(true);

        if (showBatteriaInRoom5)
            BatteriaInRoom5.SetActive(true);

        if (haveKeyFromRoom5)
        {
            showGuiKey.SetActive(true);
        }
        else
        {
            showGuiKey.SetActive(false);
        }


        IntroducePassword();

        /*if (havePassword)
            IntroducePassT.SetActive(true);*/

       if(showKeyboard)
            Keyboard.SetActive(true);

        if (!showKeyboard)
            Keyboard.SetActive(false);        

    }   

   

        void IntroducePassword()
    {
        if(showBatteriaInRoom5 && haveTheBaterieFromRoom1)
        {
            showGuiBateria.SetActive(false);
            askPass.SetActive(true);
            canGoGetCode = true;
        }
        if (askPass)
        {                      
            if (string.Equals(InputText.currentPassword, randomPassword.ToString()))
            {
                
                canGoElevator = true;
                showKeyboard = false;
                Lights.gameObject.SetActive(true);
                foreach (GameObject LightTexture in LightTextures)
                {
                    LightTexture.SetActive(true);
                }
            }

            }

        }

   public void LoadLevels()
    {

        if (canGoElevator)
            Application.LoadLevel(0);

    }

    private void makePassword()
    {     
        randomPassword = Random.Range(1000, 9999);           
        Mathf.RoundToInt(randomPassword);
        Debug.Log("rpass= " + randomPassword);
    }


}
