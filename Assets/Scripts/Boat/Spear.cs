<<<<<<< HEAD
﻿using Assets;
using System.Collections.Generic;
using UnityEngine;

public class Spear : MonoBehaviour
{
=======
﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spear : MonoBehaviour {

>>>>>>> 65c7c47a86a4ee5bdcba084cc2d5f5c563c53c6c
    public float speed = 5;
    public float lifeTime = 3;

<<<<<<< HEAD
    public float maxLifeTime = 1f;
    public float lifeTime = 0;

    //Retractuibn tine in seconds
    public float retractingTime = 1;

    
=======
>>>>>>> 65c7c47a86a4ee5bdcba084cc2d5f5c563c53c6c
    bool shot = false;

    //used for shoot directing
    public Vector3 movementDirection;

<<<<<<< HEAD
    //Used for retraction
    Vector3 startPosition;
    Vector3 fromPosition;
    float retractingAmount = 0;
    public bool retracting = false;

    List<GameObject> caughtFish;

    GUI gameGui;

    LineRenderer line;

    private void Start()
    {
        startPosition = transform.position;
        gameGui = GameObject.FindGameObjectWithTag(Tags.MainCamera).GetComponent<GUI>();

        caughtFish = new List<GameObject>();

        line = GetComponent<LineRenderer>();
    }

    public bool canShoot()
    {
        return !shot;
    }

=======
>>>>>>> 65c7c47a86a4ee5bdcba084cc2d5f5c563c53c6c
    //Shoot the spear in a direction
    public void Shoot(Vector3 newDirection)
    {
        movementDirection = (newDirection - transform.position).normalized;
        transform.rotation = Quaternion.AngleAxis(Mathf.Atan2(newDirection.y, newDirection.x) * Mathf.Rad2Deg, Vector3.forward);

        shot = true;
    }

    // Update is called once per frame
    void Update()
    {
        //If the spear has been shot
        if (shot)
        {
            //Move spear
            transform.position += (movementDirection * speed) * Time.deltaTime;

            //Reduce lifetime
            lifeTime -= Time.deltaTime;

            if (lifeTime <= 0)
            {
<<<<<<< HEAD
                fromPosition = transform.position;
                retractingAmount = 0;
                retracting = true;
            }
        }
        else if (retracting)
        {
            retractingAmount += (Time.deltaTime / retractingTime);

            transform.position = Vector3.Lerp(fromPosition, startPosition, retractingAmount);

            line.SetPosition(1, transform.position);

            if (retractingAmount >= 1)
            {
                //When we catch the fish
                while(caughtFish.Count != 0)
                {
                    switch(caughtFish[0].GetComponent<fishScript>().fish)
                    {
                        case FishType.Green:
                            gameGui.GreenFish++;
                            break;

                        case FishType.Purple:
                            gameGui.PurpleFish++;
                            break;

                        case FishType.Red:
                            gameGui.RedFish++;
                            break;

                        case FishType.Yellow:
                            gameGui.YellowFish++;
                            break;

                        case FishType.Angela:
                            gameGui.AnglaFish++;
                            break;
                    }

                    Destroy(caughtFish[0]);
                    caughtFish.RemoveAt(0);
                }

                line.enabled = false;
                shot = false;
                retracting = false;

                transform.position = startPosition;
=======
                Destroy(gameObject);
>>>>>>> 65c7c47a86a4ee5bdcba084cc2d5f5c563c53c6c
            }
        }
        
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if(shot && !retracting)
        {
            if(collider.tag == Tags.Fish)
            {
                caughtFish.Add(collider.gameObject);
                collider.GetComponent<fishScript>().SetSpear(gameObject);
                collider.GetComponent<fishScript>().caught = true;
            }
        }
    }
}
