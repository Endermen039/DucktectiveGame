using UnityEngine;

public class BasicTriggerScript : MonoBehaviour
{

    private bool playerInRange = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Interact()
    {
        Debug.Log("Square was interacted with!");
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
            Debug.Log(gameObject.name + " was triggered by " + other.name);
            other.GetComponent<PlayerInteractScript>().SetInteractable(this);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
            Debug.Log(gameObject.name + " left the trigger " + other.name);
            other.GetComponent<PlayerInteractScript>().ClearInteractable(this);
        }
    }

}
