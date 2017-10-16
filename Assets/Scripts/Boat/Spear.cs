using Assets;
using System.Collections.Generic;
using UnityEngine;

public class Spear : MonoBehaviour
{
    public float speed = 5;

    public float maxLifeTime = 1f;
    public float lifeTime = 0;

    //Retractuibn tine in seconds
    public float retractingTime = 1;

    
    bool shot = false;

    //used for shoot directing
    public Vector3 movementDirection;

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

    //Shoot the spear in a direction
    public void Shoot(Vector3 newDirection)
    {
        newDirection.z = transform.position.z;
        movementDirection = (newDirection - transform.position).normalized;

        transform.rotation = Quaternion.AngleAxis(Mathf.Atan2(newDirection.y, newDirection.x) * Mathf.Rad2Deg, Vector3.forward);

        lifeTime = maxLifeTime;

        line.SetPosition(0, startPosition);
        line.SetPosition(1, transform.position);

        line.enabled = true;

        shot = true;
    }

    // Update is called once per frame
    void Update()
    {
        //If the spear has been shot
        if (shot && !retracting)
        {
            //Move spear
            transform.position += (movementDirection * speed) * Time.deltaTime;

            line.SetPosition(1, transform.position);

            //Reduce lifetime
            lifeTime -= Time.deltaTime;

            if (lifeTime <= 0)
            {
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
                            gameGui.AngelaFish++;
                            break;
                    }

                    Destroy(caughtFish[0]);
                    caughtFish.RemoveAt(0);
                }

                line.enabled = false;
                shot = false;
                retracting = false;

                transform.position = startPosition;
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
