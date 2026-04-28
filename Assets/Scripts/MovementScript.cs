using UnityEngine;
using UnityEngine.InputSystem;

public class MovementScript : MonoBehaviour
{
    public InputAction MoveAction;
    public InputAction PointAction;
    private GunScript gunScript;
    private Rigidbody2D rb;
    public float speed = 7.0f;

    // Start is called at the start of execution once

    void Start()
    {
        MoveAction.Enable();
        PointAction.Enable();
        rb = GetComponent<Rigidbody2D>();
        gunScript = GetComponentInChildren<GunScript>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 mouseWorldPos = GetPointerInput();

        if (gunScript != null)
        {
            gunScript.Aim(mouseWorldPos);
        }
    }

    private void FixedUpdate()
    {
        Vector2 move = MoveAction.ReadValue<Vector2>();
        rb.linearVelocity = move.normalized * speed;
    }

    private Vector2 GetPointerInput()
    {
        Vector3 mousPos = PointAction.ReadValue<Vector2>();
        mousPos.z = Camera.main.nearClipPlane;
        return Camera.main.ScreenToWorldPoint(mousPos);
    }

}

