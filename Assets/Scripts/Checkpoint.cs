using UnityEngine;
using UnityEngine.Events;

public class Checkpoint : MonoBehaviour
{

    [SerializeField] private UnityEvent _onUpdateCheckPoint = new();
    public void UpdateCheckPoint()
    {
        Debug.Log("Set spawn point at");
        GameManager.Instance.CurrentSpawnPoint = gameObject;
        _onUpdateCheckPoint.Invoke();
    }
}
