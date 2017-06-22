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
    
    void Update()
    {
        if(PlayerPrefs.GetInt("Survival Unlocked") == 1)
        {
            survivalmodebutton.interactable = true;
        }
    }
	
    public void btnStoryMode()
    {
        SceneManager.LoadScene("MainGame");
    }

    public void btnSurvivalMode()
    {
        SceneManager.LoadScene("SurvivalMode");
    }
}
