using UnityEngine;

public class EnemyScript : MonoBehaviour
{

    [SerializeField] private GameObject uiHealth1;
    [SerializeField] private GameObject uiHealth2;
    [SerializeField] private GameObject uiHealth3;

    private bool canTakeDamage = true;

    public int playerHealth = 3;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Something triggered");

        if (!canTakeDamage) { return; }

        if (other.CompareTag("Player"))
        {
            Debug.Log("Player triggered");

            if (playerHealth == 3)
            {
                uiHealth3.SetActive(false);
                playerHealth--;
            }
            else if (playerHealth == 2)
            {
                uiHealth2.SetActive(false);
                playerHealth--;
            }
            else if (playerHealth == 1)
            {
                uiHealth1.SetActive(false);
                playerHealth--;
                canTakeDamage = false;
            }

        }
    }

}
