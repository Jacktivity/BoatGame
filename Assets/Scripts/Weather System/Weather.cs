using UnityEngine;

public class Weather : MonoBehaviour
{

    //Wind speed pushing the boat
    public float windSpeed = 0;
    [Range(5.0f, 16.0f)]
    public float maxWindSpeed = 15;
    
    //used to quickly or slowly reduce wind speed
    public float windReduceMultiplier = 2;

    float windDifference = 0;

    //possible for more unpredictable waves
    // 1.0 - 3.0 more than 3 reduces the chance of waves moving side to side often
    [Range(1.0f, 3.0f)]
    public float difficultyMultiplier = 1;

    //Delays stopping the boat constantly moving
    float timeDelay = 0;
    
    // 4 seconds delay
    public float maxWindDelay = 1.5f;

    // Use this for initialization
    void Start()
    {

    }

    //Add random wind
    void AddWind(float addWindSpeed)
    {
        windDifference += addWindSpeed;
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

        if (timeDelay <= 0)
        {
            int rand = Random.Range(0, 100);

            //Add wind speed difference
            if (rand > 62 && rand < 66)
            {
                AddGust();
            }
            else
                AddWind(Random.Range(-maxWindSpeed, maxWindSpeed));

            //Clamp windDifferect stopping it from going one direction to much
            windDifference = Mathf.Clamp(windDifference, -(maxWindSpeed * difficultyMultiplier), (maxWindSpeed * difficultyMultiplier));

            //Update windSpeed;
            windSpeed += windDifference;

            //Clamp wind speed
            windSpeed = Mathf.Clamp(windSpeed, -maxWindSpeed, maxWindSpeed);

            timeDelay = Random.Range(0.0f, maxWindDelay);
        }
        else
        {
            timeDelay -= Time.deltaTime;

            if(windSpeed > 0)
            {
                windSpeed -= (windReduceMultiplier * Time.deltaTime);
                if (windSpeed < 0)
                    windSpeed = 0;
            }
            else if(windSpeed < 0)
            {
                windSpeed += (windReduceMultiplier * Time.deltaTime);
                if (windSpeed > 0)
                    windSpeed = 0;
            }
        }
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
