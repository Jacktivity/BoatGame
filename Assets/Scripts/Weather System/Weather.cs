using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weather : MonoBehaviour
{

    //Wind speed pushing the boat
    public float windSpeed = 0;
    public float maxWindSpeed = 15;

    public float windDifference = 0;
    public float difficultyMultiplier = 1;

    // Use this for initialization
    void Start()
    {

    }

    //Add random wind
    void AddWind(float addWindSpeed)
    {
        windDifference += (addWindSpeed * Time.deltaTime);
    }

    //Add a Gust of wind
    void AddGust()
    {
        int rand = Random.Range(0, 2);

        if (rand == 0)
        {
            windDifference = -(maxWindSpeed * difficultyMultiplier);
        }
        else
        {
            windDifference = (maxWindSpeed * difficultyMultiplier);
        }
    }


    // Update is called once per frame
    void Update()
    {

        int rand = Random.Range(0, 100);
        //Add wind speed difference
        if (rand > 62 && rand < 66)
        {
            AddGust();
        }

        AddWind(Random.Range(-maxWindSpeed, maxWindSpeed));

        //Clamp windDifferect stopping it from going one direction to much
        windDifference = Mathf.Clamp(windDifference, -(maxWindSpeed * difficultyMultiplier), (maxWindSpeed * difficultyMultiplier));

        //Update windSpeed;
        windSpeed += (windDifference * Time.deltaTime);

        //Clamp wind speed
        windSpeed = Mathf.Clamp(windSpeed, -maxWindSpeed, maxWindSpeed);
    }


    public float GetMaxWindSpeed()
    {
        return maxWindSpeed;
    }

    public float GetWindSpeed()
    {
        return windSpeed;
    }
}
