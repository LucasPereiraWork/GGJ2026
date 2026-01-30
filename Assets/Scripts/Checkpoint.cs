using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public void UpdateCheckPoint()
    {
        GameManager.Instance.CurrentSpawnPoint = gameObject;
    }
}
