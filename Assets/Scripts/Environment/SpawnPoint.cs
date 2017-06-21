using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour {

    public GameObject greenFish;
    public GameObject purpleFish;
<<<<<<< HEAD
=======
    public GameObject yellowFish;
    public GameObject redFish;
>>>>>>> bb7a37a39446f960628140d14d795d6463e8dcb8
    public GameObject theFish;
    int randFish;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
       Vector3 spawnPos = transform.position;
<<<<<<< HEAD
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
=======
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
>>>>>>> bb7a37a39446f960628140d14d795d6463e8dcb8
            Instantiate(theFish, spawnPos, transform.rotation);
        }
    }
}
