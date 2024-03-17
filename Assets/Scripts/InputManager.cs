using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InputManager : MonoBehaviour
{
    Vector3 startTouchPosition;
    Vector3 endTouchPosition;
    public static event Action<IMove> OnPlayerMovement;

    void Update()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            startTouchPosition = Input.GetTouch(0).position;
        }
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
        {
            endTouchPosition = Input.GetTouch(0).position;
            if (endTouchPosition.x > startTouchPosition.x)
            {
                IMove somethingMove = new MoveRight();
                OnPlayerMovement?.Invoke(somethingMove);
            }
            if (endTouchPosition.x < startTouchPosition.x)
            {
                IMove somethingMove = new MoveLeft();
                OnPlayerMovement?.Invoke(somethingMove);
            }
            if(endTouchPosition.x == startTouchPosition.x)
            {
                IMove somethingMove = new MoveForward();
                OnPlayerMovement?.Invoke(somethingMove);
            }
        }
    }
}
