using UnityEngine;

public class InteractableMask : MonoBehaviour, IInteractable
{
    public void DeregisterInteractable()
    {
        GameManager.Instance.RegisterInteractable(null);
    }

    public void Interact()
    {
        //Unlock mask in player or something
        Destroy(gameObject);
    }

    public void RegisterInteractable()
    {
        GameManager.Instance.RegisterInteractable(gameObject);
    }

     
}
