using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float maxHealth = 100;
    [SerializeField] private float minHealth = 0;
    [SerializeField] private Slider healthBarr;

    private float currentHealth;
    private bool _isDefeated = false;

    [SerializeField] private UnityEvent onDefeat = new();
    [SerializeField] private UnityEvent onDamage = new();

    public float MaxHealth => maxHealth;
    public float CurrentHealth => currentHealth;
    public bool IsDefeated => _isDefeated;

    private void Awake()
    {
        currentHealth = MaxHealth;
    }

    private void CalculateHealth(float delta)
    {
        if (_isDefeated) return;
        currentHealth = CurrentHealth - delta;
        currentHealth = Mathf.Clamp(CurrentHealth, minHealth, MaxHealth);
        healthBarr.value = currentHealth / maxHealth;
        if (CurrentHealth <= minHealth)
        {
            Death();
        }
        else
        {
            onDamage.Invoke();
        }
    }

    public void TakeDamage(GameObject damageDealer, bool isDamage, float damage)
    {
        if (damageDealer == null || _isDefeated) return;
        CalculateHealth(damage);
    }

    public virtual void TakeDamage(GameObject damageDealer, bool isDamage, float damage, float force, Vector2 dir)
    {
        TakeDamage(damageDealer, isDamage, damage);
        rb.AddForce(dir * force, ForceMode2D.Impulse);
    }

    private void Death()
    {
        _isDefeated = true;
        onDefeat.Invoke();
    }


}
