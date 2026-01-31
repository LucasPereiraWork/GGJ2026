using System;
using UnityEngine;
using UnityEngine.UI;
public class HUD : MonoBehaviour
{
    [SerializeField] private Slider healthBar;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private int MaxHealth;
    private void SetupHealthBar(GameObject player)
    {
        healthBar.value = healthBar.maxValue;
        MaxHealth = player.GetComponent<PlayerHealth>().maxHealth;

    }
    private void UpdateHealthBar(int currentHealth)
    {
        healthBar.value = (float)currentHealth / MaxHealth;
        healthBar.value = Mathf.Clamp01(healthBar.value);
    }

    private void OnEnable()
    {
        GameController.OnPlayerSpawned += SetupHealthBar;
        PlayerHealth.OnPlayerTakeDemage += UpdateHealthBar;
    }

    private void OnDisable()
    {
        GameController.OnPlayerSpawned -= SetupHealthBar;
        PlayerHealth.OnPlayerTakeDemage -= UpdateHealthBar;
    }
}
