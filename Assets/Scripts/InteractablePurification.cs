using UnityEngine;

public class InteractablePurification : MonoBehaviour, IInteractable
{

    [SerializeField] private GameObject door;


    public void DeregisterInteractable()
    {
        GameManager.Instance.RegisterInteractable(null);
    }

    public void Interact()
    {
        //see if player has mask
        door.SetActive(false);
    }

    public void RegisterInteractable()
    {
        GameManager.Instance.RegisterInteractable(gameObject);
    }
}
