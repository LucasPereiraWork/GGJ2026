using UnityEngine;
using System.Collections;

public class DeathZone : MonoBehaviour
{
    [SerializeField] private int totalDamage = 10;
    [SerializeField] private float fallDuration = 0.5f;

    private BoxCollider2D holeCollider;
    private bool isFalling = false;

    void Start()
    {
        holeCollider = GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        if (isFalling) return;

       
        Collider2D playerCol = Physics2D.OverlapBox(transform.position, holeCollider.bounds.size, 0, LayerMask.GetMask("Player"));

        if (playerCol != null && playerCol.CompareTag("Player"))
        {
            if (IsPlayerFullyInside(playerCol))
            {
                StartCoroutine(FallDamageRoutine(playerCol.gameObject));
            }
        }
    }

    private bool IsPlayerFullyInside(Collider2D playerCol)
    {
        
        Bounds hb = holeCollider.bounds;
        Bounds pb = playerCol.bounds;

        return pb.min.x >= hb.min.x &&
               pb.max.x <= hb.max.x &&
               pb.min.y >= hb.min.y &&
               pb.max.y <= hb.max.y;
    }

    private IEnumerator FallDamageRoutine(GameObject player)
    {
        isFalling = true;
        PlayerHealth health = player.GetComponent<PlayerHealth>();
        Vector3 initialScale = player.transform.localScale;
        float elapsed = 0f;

        // Trava controles e física
        if (player.TryGetComponent(out PlayerControls pc)) pc.enabled = false;
        if (player.TryGetComponent(out Rigidbody2D rb)) rb.linearVelocity = Vector2.zero;

        while (elapsed < fallDuration)
        {
            elapsed += Time.deltaTime;
            float progress = elapsed / fallDuration;

            health.TakeDemage(Mathf.RoundToInt((totalDamage / fallDuration) * Time.deltaTime));

    
           
            player.transform.localScale = Vector3.Lerp(initialScale, Vector3.zero, progress);

            yield return null;
        }

        player.SetActive(false);
    }
}