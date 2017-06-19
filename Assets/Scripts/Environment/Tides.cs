﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tides : MonoBehaviour
{
    public float speed;
    public float ySpeed;
    public float distance;
    public Vector3 startPos;
    public float startPosX;
    // Use this for initialization
    void Start()
    {
        //speed = 0;
        startPos = gameObject.GetComponent<Transform>().position;
        //distance = -46.5f;


    }

    // Update is called once per frame
    void Update()
    {

        gameObject.GetComponent<Transform>().position = new Vector3(gameObject.GetComponent<Transform>().position.x - speed, gameObject.GetComponent<Transform>().position.y + ySpeed);
      

        if (gameObject.GetComponent<Transform>().position.x <= distance)
        {
            gameObject.GetComponent<Transform>().position = new Vector3(22.8f, gameObject.GetComponent<Transform>().position.y);
        }
        if (gameObject.GetComponent<Transform>().position.y >= startPos.y +0.1)
        {
            ySpeed *=  -1;
        }
        else if (gameObject.GetComponent<Transform>().position.y <= startPos.y - 0.1)
        {
            ySpeed *= -1;
        }
        
    }
    
}
    