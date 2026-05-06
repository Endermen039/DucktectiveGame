using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;
using System.Collections;

public class GunScript : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    [SerializeField] private Transform playerTarget;
    [SerializeField] private GameObject reloadText;

    private Transform playerPos;

    public GameObject bulletPrefab;
    private GameObject bullet;
    private float nextShootTime = 0f;
    public int curAmmo = 6;
    private bool mustReload = false;

    public InputAction shootAction;
    private float gunCooldown = 0.75f;

    public InputAction reloadAction;
    private float nextReloadTime = 0f;
    private float reloadCooldown = 3.0f;
    private bool isReloading = false;

    public Vector2 pointerPosition { get; set; }
    public Vector2 AimPosition { get; private set; }
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        playerPos = GetComponentInParent<Transform>();

        shootAction.Enable();
        reloadAction.Enable();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 screenPos = Camera.main.WorldToScreenPoint(playerPos.position);
        screenPos.x -= 20f;
        screenPos.y += 115f;
        reloadText.transform.position = screenPos;

        if (shootAction.WasPressedThisFrame() && Time.time >= nextShootTime && !isReloading)
        {
            Shoot();
            nextShootTime = Time.time + gunCooldown;
        }
        if (reloadAction.WasPressedThisFrame() && Time.time >= nextReloadTime && curAmmo < 6)
        {
            Reload();
            nextReloadTime = Time.time + reloadCooldown;
        }
        if (curAmmo == 0)
        {
            Reload();
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
        if (mustReload == false && curAmmo != 0)
        {
            Vector3 spawnOffset = transform.right * 0.5f;
            bullet = Instantiate(bulletPrefab, transform.position + spawnOffset, transform.rotation);
            curAmmo--;
        }
        else if(curAmmo == 0){
            mustReload = true;
        }

    }

    public void Reload()
    {
       if (isReloading) { return; }
       StartCoroutine(ReloadCoroutine());
       mustReload = false;
    }

    private IEnumerator ReloadCoroutine()
    {
        isReloading = true;
        reloadText.SetActive(true);
        yield return new WaitForSeconds(3);
        curAmmo = 6;
        reloadText.SetActive(false);
        isReloading = false;
    }

}
