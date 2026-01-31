using UnityEngine;
using UnityEngine.Events;

public class InteractableMask : MonoBehaviour, IInteractable
{

    [SerializeField] private UnityEvent _onInteract;
    public void DeregisterInteractable()
    {
        GameManager.Instance.RegisterInteractable(null);
    }

    public void Interact()
    {
        //Unlock mask in player or something
        _onInteract.Invoke();
        Destroy(gameObject);
    }

    public void RegisterInteractable()
    {
        GameManager.Instance.RegisterInteractable(gameObject);
    }

     
}
