using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardInputManager : InputManager
{
    public static event MoveInputHandler MoveInput;
    public static event RotateInputHandler RotateInput;
    public static event ZoomInputHandler ZoomInput;

    void Update()
    {
        //Movement
        if (Input.GetKey(KeyCode.W))
        { MoveInput?.Invoke(Vector3.forward); }
        if (Input.GetKey(KeyCode.S))
        { MoveInput?.Invoke(-Vector3.forward); }
        if (Input.GetKey(KeyCode.A))
        { MoveInput?.Invoke(-Vector3.right); }
        if (Input.GetKey(KeyCode.D))
        { MoveInput?.Invoke(Vector3.right); }

        //Rotation
        if (Input.GetKey(KeyCode.Q))
        { RotateInput?.Invoke(-1f); }
        if (Input.GetKey(KeyCode.E))
        { RotateInput?.Invoke(1f); }

        //Zoom
        if (Input.GetKey(KeyCode.Z))
        { ZoomInput?.Invoke(-1f); }
        if (Input.GetKey(KeyCode.X))
        { ZoomInput?.Invoke(1f); }
    }
}
