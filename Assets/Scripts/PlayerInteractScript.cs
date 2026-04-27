using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInteractScript : MonoBehaviour
{

    public InputAction interactAction;
    private BasicTriggerScript currentObject;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        interactAction.Enable();
    }

    // Update is called once per frame
    void Update()
    {
        if (interactAction.triggered && currentObject != null)
        {
            currentObject.Interact();
        }
    }

    public void SetInteractable(BasicTriggerScript obj)
    {
        currentObject = obj;
    }

    public void ClearInteractable(BasicTriggerScript obj)
    {
        if (currentObject == obj)
        {
            currentObject = null;
        }
    }

}
