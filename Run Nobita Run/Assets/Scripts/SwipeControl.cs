using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeControl : MonoBehaviour
{
    private Vector2 fingerDownPosition;
    private Vector2 fingerUpPosition;

    public float minSwipeDistance = 20f;

    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                fingerDownPosition = touch.position;
                fingerUpPosition = touch.position;
            }

            if (touch.phase == TouchPhase.Moved || touch.phase == TouchPhase.Ended)
            {
                fingerUpPosition = touch.position;
                CheckSwipe();
            }
        }
    }

    void CheckSwipe()
    {
        float swipeDistance = (fingerUpPosition - fingerDownPosition).magnitude;

        if (swipeDistance > minSwipeDistance)
        {
            Vector2 swipeDirection = fingerUpPosition - fingerDownPosition;

            if (Mathf.Abs(swipeDirection.x) > Mathf.Abs(swipeDirection.y))
            {
                // Horizontal swipe
                if (swipeDirection.x < 0)
                {
                    // Left swipe action
                    Debug.Log("Left Swipe");
                }
                else
                {
                    // Right swipe action
                    Debug.Log("Right Swipe");
                }
            }
            else
            {
                // Vertical swipe
                if (swipeDirection.y < 0)
                {
                    // Down swipe action
                    Debug.Log("Down Swipe");
                }
                else
                {
                    // Up swipe action
                    Debug.Log("Up Swipe");
                }
            }
        }
    }
}


