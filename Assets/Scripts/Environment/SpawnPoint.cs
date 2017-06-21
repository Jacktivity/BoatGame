using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour {

    public GameObject greenFish;
    public GameObject purpleFish;
    public GameObject yellowFish;
    public GameObject redFish;
    public GameObject theFish;
    int randFish;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
       Vector3 spawnPos = transform.position;
        if (Random.Range(0, 100) >= 98)
        {
            randFish = Random.Range(0, 100);
            if (randFish < 70 )
            {
                theFish = greenFish;
            }
            else if (randFish < 85 && randFish >= 75)
            {
                theFish = purpleFish;
            }
            else if (randFish < 98 && randFish >=90)
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
}
