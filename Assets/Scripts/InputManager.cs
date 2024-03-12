using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public static event Action<DirectionMovement> OnPlayerMovement;
    public enum DirectionMovement
    {
        Forward,
        Left,
        Right
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            OnPlayerMovement?.Invoke(DirectionMovement.Forward);
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            OnPlayerMovement?.Invoke(DirectionMovement.Left);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            OnPlayerMovement?.Invoke(DirectionMovement.Right);
        }
    }

    
}
