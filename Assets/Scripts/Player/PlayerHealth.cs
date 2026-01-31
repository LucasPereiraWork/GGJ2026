using System;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int health = 10;

    public int currentHealth { get; private set; }
    public int maxHealth { get; private set; }
    public static Action<int> OnPlayerTakeDemage;
    void Awake()
    {
        currentHealth = health;
        maxHealth = health;
    }

    public void TakeDemage(int damageAmount)
    {
        currentHealth -= damageAmount;
        OnPlayerTakeDemage?.Invoke(currentHealth);
        if(currentHealth <= 0) {
            Destroy(gameObject);
        }

    }
}
