using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spear : MonoBehaviour {

    public float speed = 5;
    public float lifeTime = 3;

    bool shot = false;

    public Vector3 movementDirection;

    //Shoot the spear in a direction
	public void Shoot(Vector3 newDirection)
    {
        movementDirection = (newDirection - transform.position).normalized;
        transform.rotation = Quaternion.AngleAxis(Mathf.Atan2(newDirection.y, newDirection.x) * Mathf.Rad2Deg, Vector3.forward);

        shot = true;
    }   
	
	// Update is called once per frame
	void Update () {
        //If the spear has been shot
        if (shot)
        {
            //Move spear
            transform.position += (movementDirection * speed) * Time.deltaTime;

            //Reduce lifetime
            lifeTime -= Time.deltaTime;

            if (lifeTime <= 0)
            {
                Destroy(gameObject);
            }
        }
	}
}
