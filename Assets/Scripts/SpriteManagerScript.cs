using UnityEngine;
using UnityEngine.UI;

public class SpriteManagerScript : MonoBehaviour
{
    [SerializeField] private Image CurrentSpriteImg;
    [SerializeField] private Sprite[] sprites;
    [SerializeField] private GameObject gunObject;

    private GunScript gunScript;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gunScript = gunObject.GetComponent<GunScript>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("UI sees ammo: " + gunScript.curAmmo);
        UpdateAmmo(gunScript.curAmmo);
    }

    public void UpdateAmmo(int currentAmmo)
    {
        CurrentSpriteImg.sprite = sprites[currentAmmo];
    }

}
