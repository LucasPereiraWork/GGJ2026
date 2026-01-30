using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public void UpdateCheckPoint()
    {
        Debug.Log("Set spawn point at");
        GameManager.Instance.CurrentSpawnPoint = gameObject;
    }
}
