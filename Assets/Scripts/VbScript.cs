using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VbScript : MonoBehaviour
{

    /*
    private Touch touch;
    private Vector2 touchPosition;
    private Quaternion rotationZ;
    private float rotationRate = 1f;
    
	
	// Update is called once per frame
	void Update ()
    {
        if ((Input.GetTouch(0).phase == TouchPhase.Stationary) || (Input.GetTouch(0).phase == TouchPhase.Moved ))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if(hit.transform.gameObject.tag=="Player")
                {
                    rotationZ = Quaternion.Euler(-touch.deltaPosition.x * rotationRate, 0f, 0f );
                    transform.rotation = rotationZ * transform.rotation;
                    Debug.Log("India Gate");
                }
            }
        }

    }
    */
    private void OnMouseDrag()
    {
        float rotationX = Input.GetAxis("Mouse X") * 200f * Mathf.Deg2Rad;

        transform.Rotate(Vector3.up, -rotationX);
       
    }
}
