using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour {

    public GameObject pausemenucanvas;
    // Use this for initialization
    void Start ()
    {
        pausemenucanvas.SetActive(false);
    }
	
	// Update is called once per frame
	void Update ()
    {
		if(Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
        {
            Vector2 touchDeltaPosition = Input.GetTouch(0).deltaPosition;
            if(touchDeltaPosition.x > 3)
            {
                pausemenucanvas.SetActive(true);
                Time.timeScale = 0f;
            }
        }
	}


}
