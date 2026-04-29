using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;

public class GunScript : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    [SerializeField] private Transform playerTarget;

    public GameObject bulletPrefab;
    private GameObject bullet;
    private float nextShootTime = 0f;

    public InputAction shootAction;
    private float gunCooldown = 0.50f;

    public Vector2 pointerPosition { get; set; }
    public Vector2 AimPosition { get; private set; }
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        shootAction.Enable();
    }

    // Update is called once per frame
    void Update()
    {
        if (shootAction.WasPressedThisFrame() && Time.time >= nextShootTime)
        {
            Shoot();
            nextShootTime = Time.time + gunCooldown;
        }
    }
    public void Aim(Vector2 target)
    {
        AimPosition = target;

        Vector2 direction = target - (Vector2)transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle);

        spriteRenderer.flipY = (angle > 90 || angle < -90);
    }
    
    public void Shoot()
    {
        bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
    }

}
