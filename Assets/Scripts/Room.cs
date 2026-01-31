using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Room : MonoBehaviour
{
    [SerializeField] private List<GameObject> doors = new();
    [SerializeField] private List<GameObject> enemies = new();
    [SerializeField] private GameObject mask;
    [SerializeField] private bool hasActivated = false;
    [SerializeField] private UnityEvent _onHasActivated;

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
        _onHasActivated.Invoke();
        foreach (GameObject go in doors)
        {
            go.SetActive(true);
        }
    }
}
