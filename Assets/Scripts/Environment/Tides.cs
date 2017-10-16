using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tides : MonoBehaviour
{
    public float speed;
    public float ySpeed;
    public float distance;
    public GameObject target;
    public float mySizeX;
    public bool behind;
    public bool move;
    public bool special;
  
    // Use this for initialization
    void Start()
    {
        ySpeed = 0;
        mySizeX = gameObject.GetComponent<SpriteRenderer>().size.x;
        move = true;
    }
    // Update is called once per frame
    void Update()
    {
        
        if (behind)
        {
            gameObject.GetComponent<Transform>().position = new Vector3((target.GetComponent<Transform>().position.x + mySizeX), gameObject.GetComponent<Transform>().position.y);
        }
        if (move == true)
        {
            transform.position += new Vector3(speed, ySpeed) * Time.deltaTime;
        }
        if (!behind || special)
        {
            move = true;
        }
        if (gameObject.GetComponent<Transform>().position.x <= distance)
        {
            target.GetComponent<Tides>().behind = false;
            behind = !behind;
            if (behind)
            {
                move = false;
            }
        }
    }
    
}
    