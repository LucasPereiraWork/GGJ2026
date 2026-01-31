using UnityEngine;

public class PlayerLucas : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            collision.gameObject.GetComponent<EnemyHealth>().TakeDamage(gameObject, true, 10, 10, Vector2.one);
        }
    }
}
