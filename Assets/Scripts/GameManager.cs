using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject Position_detector;
    public GameObject Collision_Detector;
    public GameObject centre_model;
    Vector3 pos_object;
    bool on_pos = false;


    void Start()
    {
        pos_object = transform.position;
    }

    void OnMouseDrag()
    {
        //Vector3 pos_mouse = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Input.mousePosition.z));
        //transform.position = new Vector3(pos_mouse.x, pos_mouse.y, transform.position.z);
        Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 14f);
        Vector3 objPosition = Camera.main.ScreenToWorldPoint(mousePosition);
        transform.position = objPosition;
    }


    void Update()
    {
        if (on_pos)
            transform.localRotation = Quaternion.identity;
    }

    public void OnMouseUp()
    {
        if (on_pos)
        {
            transform.position = Position_detector.transform.position;
            //transform.rotation = Quaternion.Euler(0f,90f,90f);
            Debug.Log("Placed at correct pos");
            transform.rotation = Quaternion.Euler(0f,90f,90f);
            gameObject.GetComponent<Rotate>().enabled = false;
        }

        else
        {
            transform.position = pos_object;
            
            //gameObject.GetComponent<VbScript>().enabled = false;
        }
    }

    public void OnTriggerStay(Collider obj)
    {
        if (obj.gameObject == Collision_Detector)
        {
            on_pos = true;
        }
    }

    public void OnTriggerExit(Collider obj)
    {
        if (obj.gameObject == Collision_Detector)
        {
            on_pos = false;
        }
    }

}