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
	
    public void btnStoryMode()
    {
        SceneManager.LoadScene("MainGame");
    }

    public void btnSurvivalMode()
    {
        SceneManager.LoadScene("SurvivalMode");
    }
}
