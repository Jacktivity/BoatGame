using UnityEngine;

public class Spear : MonoBehaviour {


    public float speed = 5;

    public float maxLifeTime = 1f;
    public float lifeTime = 0;

    //Retractuibn tine in seconds
    public float retractingTime = 1;

    public bool retracting = false;
    bool shot = false;

    public Vector3 movementDirection;

    Vector3 startPosition;
    Vector3 fromPosition;
    float retractingAmount = 0;

    LineRenderer line;

    private void Start()
    {
        startPosition = transform.position;

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
	void Update () {
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
        else if(retracting)
        {
            retractingAmount += (Time.deltaTime / retractingTime);

            transform.position = Vector3.Lerp(fromPosition, startPosition, retractingAmount);
            line.SetPosition(1, transform.position);

            if (retractingAmount >= 1)
            {
                shot = false;
                retracting = false;
                line.enabled = false;

                transform.position = startPosition;
            }
        }
	}
}
