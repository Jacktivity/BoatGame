using Assets;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BoatRocker : MonoBehaviour
{

    // >0 = pushing right. <0 pushing left
    public float pushingForce = 0;
    public float loseAngle = 25;    

    public Weather currentWeather;

    // Use this for initialization
    void Start()
    {
       //Only works with standalone version of android
        //Comment if statement to work with unity remote
#if UNITY_IOS || UNITY_ANDROID
        Screen.orientation = ScreenOrientation.Landscape;
#endif
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

        if (euler.z > loseAngle && euler.z < (360 - loseAngle))
        {
            PlayerPrefs.SetInt("Winner", 0);
            SceneManager.LoadScene("End Screen");
        }
    }

    // Update is called once per frame
    void Update()
    {


/*#if UNITY_STANDALONE || UNITY_EDITOR_WIN
        //Get player pushing force
        pushingForce = (currentWeather.GetMaxWindSpeed() * 2) * Input.GetAxis(Tags.Horizontal);
        */
#if UNITY_ANDROID
        //Get player pushing force
        pushingForce = (currentWeather.GetMaxWindSpeed() * 3) * Input.acceleration.x;
        
#endif

        //Adjust the boats balance
        adjustBalance(currentWeather.GetWindSpeed(), pushingForce);

        //Check if we are still okay
        checkBalance();
    }
}
