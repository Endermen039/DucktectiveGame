using UnityEngine;

public class GunScript : MonoBehaviour
{

    [SerializeField] private Transform playerTarget;
    private Vector2 gunLocation;
    public Vector2 pointerPosition { get; set; }
    public Vector2 AimPosition { get; private set; }
    private SpriteRenderer spriteRenderer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.right = (pointerPosition - (Vector2)transform.position).normalized;
    }
    public void Aim(Vector2 target)
    {
        AimPosition = target;

        Vector2 direction = target - (Vector2)transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle);

        spriteRenderer.flipY = (angle > 90 || angle < -90);
    }

}
