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
    public GameObject sp1;
    public GameObject sp2;
    public GameObject sp3;
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

        sp1.SetActive(true);
        sp2.SetActive(true);
        sp3.SetActive(true);
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
                sp1.SetActive(false);
                sp2.SetActive(false);
                sp3.SetActive(false);
            }
        }
	}

    public void backtogame()
    {
        Time.timeScale = 1f;
        paused = false;
        pausemenucanvas.SetActive(false);
        sp1.SetActive(true);
        sp2.SetActive(true);
        sp3.SetActive(true);
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
