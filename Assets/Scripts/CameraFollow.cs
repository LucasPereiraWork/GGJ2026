using UnityEngine;
using Unity.Cinemachine; // Namespace correto para a versão 3.x

public class CameraFollow : MonoBehaviour
{
    private CinemachineCamera vcam;

    private void Awake()
    {
        
        vcam = GetComponent<CinemachineCamera>();
    }

    private void OnEnable()
    {
        // Se inscreve no evento que você criou no GameController
        GameController.OnPlayerSpawned += HandlePlayerSpawned;
    }

    private void OnDisable()
    {
        
        GameController.OnPlayerSpawned -= HandlePlayerSpawned;
    }

    private void HandlePlayerSpawned(GameObject player)
    {
        if (vcam != null && player != null)
        {
            
            vcam.Follow = player.transform;


            vcam.LookAt = player.transform;
        }
    }
}