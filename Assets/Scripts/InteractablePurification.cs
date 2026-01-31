using UnityEngine;
using UnityEngine.Events;

public class InteractablePurification : MonoBehaviour, IInteractable
{

    [SerializeField] private UnityEvent _onInteract;


    public void DeregisterInteractable()
    {
        GameManager.Instance.RegisterInteractable(null);
    }

    public void Interact()
    {
        //see if player has mask
        _onInteract.Invoke();
    }

    public void RegisterInteractable()
    {
        GameManager.Instance.RegisterInteractable(gameObject);
    }
}
