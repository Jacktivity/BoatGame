using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {

    public GameObject pausemenucanvas;
    private bool paused;
    // Use this for initialization
    void Start ()
    {
        pausemenucanvas.SetActive(false);
        Time.timeScale = 1f;
    }
	
	// Update is called once per frame
	void Update ()
    {
		if(Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
        {
            Vector2 touchDeltaPosition = Input.GetTouch(0).deltaPosition;
            if(touchDeltaPosition.x > 26 && !paused)
            {
                pausemenucanvas.SetActive(true);
                Time.timeScale = 0f;
                paused = true;
            }
        }
	}

    public void backtogame()
    {
        Time.timeScale = 1f;
        paused = false;
        pausemenucanvas.SetActive(false);
    }

    public void backtomm()
    {
        SceneManager.LoadScene("Main Menu");
    }

    public void volumemute()
    {
    }

}
