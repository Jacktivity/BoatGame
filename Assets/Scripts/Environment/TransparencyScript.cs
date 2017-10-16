﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;


public class TransparencyScript : MonoBehaviour {
    public float n;
    public float alphaOfColour;
    public Color theColour;
 
    // Use this for initialization
    void Start ()
    {
        n = -0.0005f;
       theColour = gameObject.GetComponent<SpriteRenderer>().color;
        


    }
  
    // Update is called once per frame
    void Update ()
    {
   
        if (theColour.a < 0) n *= -1; ;
        if (theColour.a >= 1) n*=-1 ;
        theColour.a -= n;
        gameObject.GetComponent<SpriteRenderer>().color = theColour;
        
       
        returnAlpha();




    }
    public  float returnAlpha()
    {
        alphaOfColour = theColour.a;
        return alphaOfColour;
        
    }

}

