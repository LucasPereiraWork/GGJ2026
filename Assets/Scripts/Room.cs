using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    [SerializeField] private List<GameObject> doors = new();
    [SerializeField] private List<GameObject> enemies = new();
    [SerializeField] private GameObject mask;
    [SerializeField] private bool hasActivated = false;

    private int enemyNum = 0;

    private void Start()
    {
        enemyNum = enemies.Count;
        mask.SetActive(false);
    }

    public void UpdateEnemies()
    {
        enemyNum--;
        CheckRoom();
    }

    private void CheckRoom()
    {
        if (enemyNum == 0)
        {
            foreach (GameObject go in doors) 
            {
                go.SetActive(false);
            }
            mask.SetActive(true);
        }
    }

    public void CloseRoom()
    {
        if (hasActivated) return;
        hasActivated = true;
        foreach (GameObject go in doors)
        {
            go.SetActive(true);
        }
    }
}
