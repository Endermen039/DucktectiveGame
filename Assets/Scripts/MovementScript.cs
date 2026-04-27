using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Windows;

public class MovementScript : MonoBehaviour
{
    public InputAction MoveAction;
    private Rigidbody2D rb;
    public float speed = 10.0f;

    // Start is called at the start of execution once

    void Start()
    {
        MoveAction.Enable();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        Vector2 move = MoveAction.ReadValue<Vector2>();
        rb.linearVelocity = move.normalized * speed;
    }

}

