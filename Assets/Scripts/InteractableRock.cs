using UnityEngine;

public class InteractableRock : MonoBehaviour, IInteractable
{
    [SerializeField] private Detector detector;
    private GameObject _player;

    public void DeregisterInteractable()
    {
        GameManager.Instance.RegisterInteractable(gameObject);
    }

    public void Interact()
    {
        _player = detector.Collider.gameObject;
        gameObject.transform.parent = _player.transform;
    }

    public void DeInteract()
    {
        gameObject.transform.parent = null;
    }

    public void RegisterInteractable()
    {
        GameManager.Instance.RegisterInteractable(null);
    }
}
