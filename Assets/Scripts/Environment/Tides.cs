using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tides : MonoBehaviour
{
    public float speed;
    public float ySpeed;
    public float distance;
    public Vector3 startPos;
    public float startPosX;
    public float resetPos;
    public GameObject target;
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

   
        transform.position += new Vector3(speed, ySpeed) * Time.deltaTime;


        if (gameObject.GetComponent<Transform>().position.x <= distance)
        {
            gameObject.GetComponent<Transform>().position = new Vector3(resetPos, gameObject.GetComponent<Transform>().position.y);
            gameObject.GetComponent<Transform>().position = new Vector3(target.GetComponent<Transform>().position.x + gameObject.GetComponent<SpriteRenderer>().size.x, gameObject.GetComponent<Transform>().position.y);
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
    