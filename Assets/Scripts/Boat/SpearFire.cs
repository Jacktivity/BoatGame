using Assets;
using UnityEngine;

public class SpearFire : MonoBehaviour
{

    //Hight under the boat that the spear needs to be fired
    public float maxSpearHeight = -10;
    public float shootDelay = 2;

    public Vector3 spearOffset;

    float remainingDelay;

    //Spear to be shot
    public GameObject spearPrefab;

    //Only hold a spear when on pc
    private GameObject heldSpear;

    private void Start()
    {
        // only spawn spear when on the pc
        SpawnHeldSpear();
    }

    //Spawn spear on boat
    void SpawnHeldSpear()
    {
        //Spear spawn position
        Vector3 spawnPos = transform.position + spearOffset;
        spawnPos.z = -1;

        //Spawn aiming down
        heldSpear = Instantiate(spearPrefab, spawnPos, Quaternion.AngleAxis(Mathf.Atan2(transform.position.y - 1, transform.position.x) * Mathf.Rad2Deg, Vector3.forward));
    }


    //Fire Spear
    void FireSpear(Vector3 firePos)
    {
        firePos.z = -1;

        //Shot the held spear
        heldSpear.GetComponent<Spear>().Shoot(firePos);
        heldSpear = null;

        //Set shoot delay
        remainingDelay = shootDelay;
    }

    // Update is called once per frame
    void Update()
    {
        //Fire spear in click/touch position
#if UNITY_STANDALONE || UNITY_EDITOR_WIN

        //Wait for the spawn delay 
        if (heldSpear != null || remainingDelay <= 0)
        {
            Vector3 mousePosition = Input.mousePosition - (new Vector3(Screen.width / 2, (Screen.height / 2) + (spearOffset.y * 63), 0));

            //If the mouse is under the ship
            if (mousePosition.y < (maxSpearHeight - spearOffset.y))
            {

                heldSpear.transform.rotation = Quaternion.AngleAxis(Mathf.Atan2(mousePosition.y, mousePosition.x) * Mathf.Rad2Deg, Vector3.forward);
                    
                    //Quaternion.LookRotation(mousePosition - heldSpear.transform.position);

                //If the player has clicked
                if (Input.GetButtonDown(Tags.Fire1))
                {
                    FireSpear(mousePosition);
                }
            }
        }
        else
        {
            remainingDelay -= Time.deltaTime;

            //Spawn spear after delay
            if(remainingDelay <= 0)
                SpawnHeldSpear();
        }


#elif UNITY_ANDROID

        if (Input.touchCount > 0)
        {
            Vector2 screenPos = Input.GetTouch(Input.touchCount - 1).position;
            Vector3 touchPosition = new Vector3(screenPos.x, screenPos.y, 0) - (new Vector3(Screen.width / 2, Screen.height / 2, 0));

            if (touchPosition.y < (maxSpearHeight + spearOffset.y))
            {
                //Fire Spear towards the newest touch on the screen
                FireSpear(touchPosition);
            }
        }

#endif
    }
}
