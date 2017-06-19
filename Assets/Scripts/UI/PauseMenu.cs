using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public Button volumemute;
    public AudioSource volumeListener;
    public GameObject pausemenucanvas;
    public Sprite imageon;
    public Sprite imageoff;
    private int muted;
    private bool paused;
    // Use this for initialization
    void Start ()
    {
        pausemenucanvas.SetActive(false);
        Time.timeScale = 1f;

        volumeListener.volume = PlayerPrefs.GetFloat("volumeListener");
        muted = PlayerPrefs.GetInt("Muted");
        checkMuteImage();
    }
	
	// Update is called once per frame
	void Update ()
    {
		if(Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
        {
            Vector2 touchDeltaPosition = Input.GetTouch(0).deltaPosition;
            if(touchDeltaPosition.x > 150 && !paused)
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



    public void mutevolume()
    {
        if (muted == 1)
        {
            PlayerPrefs.SetInt("Muted", 0);
            muted = PlayerPrefs.GetInt("Muted");

            volumeListener.volume = 1f;
            PlayerPrefs.SetFloat("volumeListener", volumeListener.volume);

            PlayerPrefs.SetInt("SpriteImage", 1);

            checkMuteImage();
        }
        else
        {
            PlayerPrefs.SetInt("Muted", 1);
            muted = PlayerPrefs.GetInt("Muted");

            volumeListener.volume = 0f;
            PlayerPrefs.SetFloat("volumeListener", volumeListener.volume);

            PlayerPrefs.SetInt("SpriteImage", 0);

            checkMuteImage();
        }
    }

    private void checkMuteImage()
    {
        if (PlayerPrefs.GetInt("SpriteImage") == 0)
        {
            volumemute.image.GetComponent<Image>().sprite = imageon;
        }
        else
        {
            volumemute.image.GetComponent<Image>().sprite = imageoff;
        }
    }

}
