using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SurvivalMode : MonoBehaviour {

    private float w = 0.0f;
    private float wThreshold = 180.0f;

    private float timeLeft;
    public Text timeText;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        w += Time.deltaTime;

        timeLeft = (w % 60);

        timeText.text = "" + Mathf.RoundToInt(timeLeft);
    }
}
