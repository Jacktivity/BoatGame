using Assets;
using UnityEngine;

public class SpearFire : MonoBehaviour
{

    //Hight under the boat that the spear needs to be fired
    public float maxSpearHeight = -10;
    public float spearRetractSpeed = 5;

    public Vector3 spearOffset;

    public GameObject spearPrefab;

    GameObject heldSpear;

    void Start()
    {
        //Spawn position
        Vector3 spawnPos = transform.position + spearOffset;

        heldSpear = Instantiate(spearPrefab, spawnPos, Quaternion.AngleAxis(Mathf.Atan2(transform.position.y - 1, transform.position.x) * Mathf.Rad2Deg, Vector3.forward));
    }

    //Fire Spear
    void FireSpear(Vector3 firePos)
    {
        firePos.z = -1;

        //Shot the held spear
        heldSpear.GetComponent<Spear>().Shoot(firePos);
    }

    // Update is called once per frame
    void Update()
    {
        //Fire spear in click/touch position
#if UNITY_STANDALONE || UNITY_EDITOR

        //Wait for the spawn delay 
        if (heldSpear.GetComponent<Spear>().canShoot())
        {
            Vector3 mousePosition = Input.mousePosition - Camera.main.WorldToScreenPoint(heldSpear.transform.position);

            //If the mouse is under the ship
            if (mousePosition.y < (maxSpearHeight - spearOffset.y))
            {
                heldSpear.transform.rotation = Quaternion.AngleAxis(Mathf.Atan2(mousePosition.y, mousePosition.x) * Mathf.Rad2Deg, Vector3.forward);

                //If the player has clicked
                if (Input.GetButtonDown(Tags.Fire1))
                {
                    FireSpear(mousePosition);
                }
            }
        }
        else
        {

        }


#elif UNITY_ANDROID

        if (Input.touchCount > 0 && heldSpear.GetComponent<Spear>().canShoot())
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
