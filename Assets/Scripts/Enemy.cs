using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int damage = 3; 

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        PlayerHealth player = collision.gameObject.GetComponent<PlayerHealth>();

        if (player != null)
        {
            player.TakeDemage(damage);
            Debug.Log("Inimigo causou " + damage + " de dano!");
        }
    }
}