using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour {

    public GameObject greenFish;
    public GameObject purpleFish;
    public GameObject yellowFish;
    public GameObject redFish;
    public GameObject nightFish;
    public GameObject theFish;
    public GameObject theSky;
    int randFish;
    public bool day;
    public float alpha;
    // Use this for initialization
    void Start ()
    {
        day = true;
	}
	
	// Update is called once per frame
	void Update ()
    {
        alpha = theSky.GetComponent<TransparencyScript>().returnAlpha();
        Vector3 spawnPos = transform.position;
        if (day)
        { 
            if (Random.Range(0, 100) >= 95)
            {
                randFish = Random.Range(0, 100);
                if (randFish < 70)
                {
                    theFish = greenFish;
                }
                else if (randFish < 85 && randFish >= 75)
                {
                    theFish = purpleFish;
                }
                else if (randFish < 98 && randFish >= 90)
                {
                    theFish = yellowFish;
                }
                else if (randFish >= 98)
                {
                    theFish = redFish;
                }
                Instantiate(theFish, spawnPos, transform.rotation);
            }
        }
        if(!day)
        {
            if (Random.Range(0, 1000) >= 998)
            {
                theFish = nightFish;
                Instantiate(theFish, spawnPos, transform.rotation);
            } 
        }
        if (alpha <= 0.5f)
        {
            day = false;
        }
        else
        {
            day = true;
        }
    }
}
