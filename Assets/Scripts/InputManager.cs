using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public static event Action<IMove> OnPlayerMovement;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            IMove somethingMove = new MoveLeft();
            OnPlayerMovement?.Invoke(somethingMove);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            IMove somethingMove = new MoveRight();
            OnPlayerMovement?.Invoke(somethingMove);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            IMove somethingMove = new MoveForward();
            OnPlayerMovement?.Invoke(somethingMove);
        }
    }

    
}
