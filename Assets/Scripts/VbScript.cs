using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VbScript : MonoBehaviour
{
    private Touch touch;
    private Vector2 touchPosition;
    private Quaternion rotationZ;
    private float rotationRate = 0.1f;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        
        //if (gameObject == centre_model || on_pos == true)
        //{
        if (Input.touchCount > 0 /*&& Input.touches[0].phase==TouchPhase.Began*/)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            RaycastHit Hit;
            if (Physics.Raycast(ray, out Hit))
            {
                if (Hit.transform.gameObject.tag == "Player")
                {
                    Debug.Log(Hit.transform.name);
                    touch = Input.GetTouch(0);
                    if (touch.phase == TouchPhase.Moved)
                    {
                        rotationZ = Quaternion.Euler(0f, 0f, -touch.deltaPosition.x * rotationRate);
                        transform.rotation = rotationZ * transform.rotation;
                    }
                }
            }

        }

    }
}
