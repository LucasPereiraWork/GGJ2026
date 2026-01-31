using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int damage = 3;
    private SpriteRenderer sr;
    private Color originalColor;
    private void Start()
    {
        sr = GetComponentInChildren<SpriteRenderer>();
        originalColor = (sr != null) ? sr.color : Color.white;  
    }
    public void GotHit()
    {
        StopAllCoroutines();
        StartCoroutine(FlashColor());
        Debug.Log("O Dummy detectou o golpe!");
    }

    private IEnumerator FlashColor()
    {
        if (sr == null) yield break;

        sr.color = Color.white; 
        yield return new WaitForSeconds(0.5f);
        sr.color = originalColor;
    }
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