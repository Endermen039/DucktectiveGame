using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Windows;

public class MovementScript : MonoBehaviour
{
    public InputAction MoveAction;

    // Start is called at the start of execution once

    void Start()
    {
        MoveAction.Enable();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 move = MoveAction.ReadValue<Vector2>();
        Vector2 position = (Vector2)transform.position + move * 0.01f;
        transform.position = position;
    }

}

