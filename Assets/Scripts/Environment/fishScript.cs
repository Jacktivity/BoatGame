using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fishScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        gameObject.GetComponent<Transform>().position = new Vector3(gameObject.GetComponent<Transform>().position.x - 0.2f, gameObject.GetComponent<Transform>().position.y);
        if (gameObject.GetComponent<Transform>().position.x <= -23)
        {
            Destroy(gameObject);
        }
       
    }
}
