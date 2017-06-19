using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class VolumeController : MonoBehaviour
{
    public Button volumemute;
    public Button volumeSMmute;
    public AudioSource volumeListener;
    public GameObject menuScreen;
    public Sprite imageon;
    public Sprite imageoff;
    private int muted;

    // Use this for initialization
    void Start()
    {
        volumeListener.volume = PlayerPrefs.GetFloat("volumeListener");
        muted = PlayerPrefs.GetInt("Muted");
        checkMuteImage();

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
            volumeSMmute.image.GetComponent<Image>().sprite = imageon;
        }
        else
        {
            volumemute.image.GetComponent<Image>().sprite = imageoff;
            volumeSMmute.image.GetComponent<Image>().sprite = imageoff;
        }
    }
}