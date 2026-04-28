using UnityEngine;

public class CrosshairScript : MonoBehaviour
{
    private GunScript gunScript;
    private SpriteRenderer spriteRenderer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gunScript = GetComponentInParent<GunScript>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (gunScript != null)
        {
            transform.position = gunScript.AimPosition;
        }
    }
}
