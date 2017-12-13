using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public static GameManager Instance;

    public bool haveKeyFromRoom5 = false;
    public bool haveTheBaterieFromRoom1 = false;
    public bool havePassword = false;
    public bool showHavePass = false;

    public bool canOpenDoorH1 = false;

    private GameObject BatteriaInRoom5;
    public bool showBatteriaInRoom5 =false;

    public GameObject askPass;
    public GameObject showPassF;

    public GameObject IntroducePassT;


    private bool canGoElevator = false;

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

        BatteriaInRoom5.SetActive(false);

        askPass.SetActive(false);
        showPassF.SetActive(false);
        IntroducePassT.SetActive(false);
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
        }
        if (havePassword && showHavePass)
        {
            askPass.SetActive(false);
            showPassF.SetActive(true);
            canGoElevator = true;
        }

    }

   public void LoadLevels()
    {

        if (canGoElevator)
            Application.LoadLevel(0);

    }
}
