using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
public class VbScript : MonoBehaviour , IPointerDownHandler
{
    float firstTapTime = 0f;
    float timeBetweenTaps = 0.2f; 
    bool doubleTapInitialized;

    public UnityEvent OnSingleTap;
    public UnityEvent OnDoubleTap;

    public void OnMouseDrag()
    {
        float rotationX = Input.GetAxis("Mouse X") * 200f * Mathf.Deg2Rad;
        transform.Rotate(Vector3.up, -rotationX);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (!doubleTapInitialized)
        {
            // invoke single tap after max time between taps
            Invoke("SingleTap", timeBetweenTaps);
            // init double tapping
            doubleTapInitialized = true;
            firstTapTime = Time.time;
        }
        else if (Time.time - firstTapTime < timeBetweenTaps)
        {
            // here we have tapped second time before "single tap" has been invoked
            CancelInvoke("SingleTap"); // cancel "single tap" invoking
            DoubleTap();
        }
    }

    void SingleTap()
    {
        doubleTapInitialized = false; // deinit double tap

        // fire OnSingleTap event for all eventual subscribers
        if (OnSingleTap != null)
        {
            OnSingleTap.Invoke();
        }
    }

    void DoubleTap()
    {
  

        doubleTapInitialized = false;
        if (OnDoubleTap != null)
        {
            OnDoubleTap.Invoke();
        }
    }
}
