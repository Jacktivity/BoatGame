using Assets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatRocker : MonoBehaviour {

    // >0 = pushing right. <0 pushing left
    public float pushingForce = 0;
    public float loseAngle = 25;

    public Weather currentWeather;

	// Use this for initialization
	void Start () {
		
	}

    //Adjusts the boats balance
    void adjustBalance(float wind, float push)
    {
        float pushBoat = push + wind;

        Vector3 euler = transform.eulerAngles;
        euler.z -= (pushBoat * Time.deltaTime);

        transform.eulerAngles = euler;
    }

    //Checks the boats balance
    void checkBalance()
    {
        Vector3 euler = transform.rotation.eulerAngles;

        if(euler.z > loseAngle && euler.z < (360 - loseAngle))
        {
            euler.z = 0;
            transform.rotation = Quaternion.Euler(euler);
        }
    }

	// Update is called once per frame
	void Update () {

        //Get player pushing force
        pushingForce = (currentWeather.GetMaxWindSpeed() * 2) * Input.GetAxis(Tags.Horizontal);

        //Adjust the boats balance
        adjustBalance(currentWeather.GetWindSpeed(), pushingForce);

        //Check if we are still okay
        checkBalance();
	}
}
