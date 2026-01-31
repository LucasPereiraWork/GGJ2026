using UnityEngine;
using UnityEngine.Events;

public class InteractablePurification : MonoBehaviour, IInteractable
{

    [SerializeField] private GameObject door;
    [SerializeField] private UnityEvent _onInteract;


    public void DeregisterInteractable()
    {
        GameManager.Instance.RegisterInteractable(null);
    }

    public void Interact()
    {
        //see if player has mask
        _onInteract.Invoke();
        door.SetActive(false);
    }

    public void RegisterInteractable()
    {
        GameManager.Instance.RegisterInteractable(gameObject);
    }
}
