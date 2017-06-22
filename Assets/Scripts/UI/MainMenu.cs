using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public GameObject menucanvas;
    public Button survivalmodebutton;

    // Use this for initialization
    void Start ()
    {
        menucanvas.SetActive(true);
        survivalmodebutton.interactable = false;
    }
<<<<<<< HEAD
=======
<<<<<<< HEAD
=======
>>>>>>> origin/master
    
    void Update()
    {
        if(PlayerPrefs.GetInt("Survival Unlocked") == 1)
        {
            survivalmodebutton.interactable = true;
        }
    }
<<<<<<< HEAD
=======
>>>>>>> bb7a37a39446f960628140d14d795d6463e8dcb8
>>>>>>> origin/master
	
    public void btnStoryMode()
    {
        SceneManager.LoadScene("MainGame");
    }

    public void btnSurvivalMode()
    {
        SceneManager.LoadScene("SurvivalMode");
    }
}
