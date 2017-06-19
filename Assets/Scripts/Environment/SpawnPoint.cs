using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour {

    public GameObject greenFish;
    public GameObject purpleFish;
    public GameObject theFish;
    int randFish;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
       Vector3 spawnPos = transform.position;
        if (Random.Range(0, 100) >= 99)
        {
            randFish = Random.Range(0, 20);
            if (randFish < 15)
            {
                theFish = greenFish;
            }
            else if (randFish >= 15)
            {
                theFish = purpleFish;
            }
            Instantiate(theFish, spawnPos, transform.rotation);
        }
    }
}
