using UnityEngine;
using System;
using System.Collections.Generic;
using System.Collections;

public class GameController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] private GameObject playerPrefab;

   
    private GameObject player;

    public static Action<GameObject> OnPlayerSpawned;


    void Awake()
    {
        player = Instantiate(playerPrefab, transform.position, Quaternion.identity);

    }
    private void Start()
    {
        OnPlayerSpawned?.Invoke(player);
    }

}
