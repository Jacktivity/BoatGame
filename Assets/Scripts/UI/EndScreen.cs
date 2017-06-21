using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndScreen : MonoBehaviour
{
    public GameObject WinnerCanvas;
    public GameObject LoserCanvas;

    public Button volumewinnermute;
    public Button volumelosermute;
    public AudioSource volumeListener;
    public GameObject menuScreen;
    public Sprite imageon;
    public Sprite imageoff;
    public Sprite secondimageon;
    public Sprite secondimageoff;
    private int muted;

    void Start ()
    {
        if(PlayerPrefs.GetInt("Winner") == 1)
        {
            PlayerPrefs.SetInt("Survival Unlocked", 1);
            WinnerCanvas.SetActive(true);
        }
        else
        {
            LoserCanvas.SetActive(true);
        }


        volumeListener.volume = PlayerPrefs.GetFloat("volumeListener");
        muted = PlayerPrefs.GetInt("Muted");
        checkMuteImage();

    }

	void Update ()
    {
		
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
            volumewinnermute.image.GetComponent<Image>().sprite = secondimageon;
            volumelosermute.image.GetComponent<Image>().sprite = imageon;
        }
        else
        {
            volumewinnermute.image.GetComponent<Image>().sprite = secondimageoff;
            volumelosermute.image.GetComponent<Image>().sprite = imageoff;
        }
    }
}
