using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public GameObject mainmenucanvas;
    public GameObject startmenucanvas;
    public Button survivalmodebutton;
    // Use this for initialization
    void Start ()
    {
        mainmenucanvas.SetActive(true);
        startmenucanvas.SetActive(false);
        survivalmodebutton.interactable = false;
    }
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public void btnStart()
    {
        mainmenucanvas.SetActive(false);
        startmenucanvas.SetActive(true);
    }

    public void btnBack()
    {
        mainmenucanvas.SetActive(true);
        startmenucanvas.SetActive(false);
    }

    public void btnExit()
    {
        Application.Quit();
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
