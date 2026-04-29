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

        Collider2D bulletCol = GetComponent<Collider2D>();
        Collider2D playerCol = GameObject.FindGameObjectWithTag("Player").GetComponent<Collider2D>();

        Physics2D.IgnoreCollision(bulletCol, playerCol);

        // Destroy after some time
        Destroy(gameObject, lifetime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            return;
        }
        
        Destroy(gameObject);
        
    }
}
