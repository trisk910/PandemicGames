using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public static GameManager Instance;

    public bool switchCharacter = false;

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

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;

        }

    }

    // Use this for initialization
    void Start () {

        BatteriaInRoom5 = (GameObject)GameObject.FindGameObjectWithTag("BatteriaH5");

        Lights = (GameObject)GameObject.FindGameObjectWithTag("Lights");

        BatteriaInRoom5.SetActive(false);

        askPass.SetActive(false);
        showPassF.SetActive(false);
        IntroducePassT.SetActive(false);

        light.GetComponent<Light>().intensity = 0;
        Lights.gameObject.SetActive(false);

        DogFunctions = FindObjectOfType<Dog>();
    }
	
	// Update is called once per frame
	void Update () {

        if (showBatteriaInRoom5)
            BatteriaInRoom5.SetActive(true);

        IntroducePassword();

        if (havePassword)
            IntroducePassT.SetActive(true);
    }

    void IntroducePassword()
    {
        if(showBatteriaInRoom5 && haveTheBaterieFromRoom1)
        {
            askPass.SetActive(true);
            canGoGetCode = true;
        }
        if (havePassword && showHavePass)
        {
            askPass.SetActive(false);
            showPassF.SetActive(true);
            canGoElevator = true;

            Lights.gameObject.SetActive(true);
        }

    }

   public void LoadLevels()
    {

        if (canGoElevator)
            Application.LoadLevel(0);

    }
}
