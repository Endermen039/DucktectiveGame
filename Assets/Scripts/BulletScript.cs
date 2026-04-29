using UnityEngine;

public class BulletScript : MonoBehaviour
{

    [SerializeField] private float bulletSpeed;
    [SerializeField] private float lifetime = 3.0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Move in the direction the bullet is facing
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.linearVelocity = transform.right * bulletSpeed;

        // Destroy after some time
        Destroy(gameObject, lifetime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
