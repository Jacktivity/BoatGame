using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GUI : MonoBehaviour
{
    public Slider HungerBar;
    public Text GreenText;
    public Text YellowText;
    public Text PurpleText;
    public Text RedText;
    public Text AnglaText;
    public Text HungerText;
    private int curhunger;
    private int maxhunger = 150;
    private float t = 0.0f;
    private float threshold = 1.0f;

    public int GreenFish;
    public int YellowFish;
    public int PurpleFish;
    public int RedFish;
    public int AngelaFish;

	void Start ()
    {
        curhunger = maxhunger;
	}
	void Update ()
    {

        HungerBar.value = curhunger;

        if (curhunger <= 0)
        {
            PlayerPrefs.SetInt("Winner", 0);
            SceneManager.LoadScene("End Screen");
        }


        t += Time.deltaTime;
        if (t >= threshold)
        {
            t = 0.0f;
            curhunger -= 2;
        }

        if(curhunger > maxhunger)
        {
            curhunger = maxhunger;
        }

        GreenText.text = "" + GreenFish;
        YellowText.text = "" + YellowFish;
        PurpleText.text = "" + PurpleFish;
        RedText.text = "" + RedFish;
        AnglaText.text = "" + AngelaFish;


        HungerText.text = "" + curhunger + "/" + maxhunger;
    }

    public void btnGreenFish()
    {
        if (GreenFish > 0)
        {
            curhunger += 3;
            GreenFish -= 1;
        }

    }

    public void btnYellowFish()
    {
        if(YellowFish > 0)
        {
            curhunger += 9;
            YellowFish -= 1;
        }
    }
    public void btnPurpleFish()
    {
        if (PurpleFish > 0)
        {
            curhunger += 19;
            PurpleFish -= 1;
        }
    }

    public void btnRedFish()
    {
        if (RedFish > 0)
        {
            curhunger += 29;
            RedFish -= 1;
        }
    }

    public void btnAnglaFish()
    {
        if (AngelaFish > 0)
        {
            curhunger += 50;
            AngelaFish -= 1;
        }
    }

}
