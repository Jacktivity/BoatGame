using Assets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fishScript : MonoBehaviour {


    public Vector3 speed;
    public bool caught = false;
    public FishType fish;

    GameObject spear;

    public void SetSpear(GameObject spearClone)
    {
        spear = spearClone;
    }

	// Update is called once per frame
	void Update ()
    {
        if (!caught)
        {
            transform.position += speed * Time.deltaTime;

            if (gameObject.GetComponent<Transform>().position.x <= -23)
            {
                Destroy(gameObject);
            }
        }
        else
        {
            GetComponent<SpriteRenderer>().sortingLayerName = Tags.SpearRenderLevel;
            transform.position = spear.transform.position;
        }
    }
}
