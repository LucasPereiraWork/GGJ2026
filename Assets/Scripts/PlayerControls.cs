using System.Collections;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public float speed = 0.5f;
    private Rigidbody2D rb;
    private Vector2 input;
    private Vector2 lastMoveDirection;
    [SerializeField] private float dashSpeed = 15f;
    [SerializeField] private float dashTime = 0.2f;
    private bool isDashing;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isDashing) return;

        input.x = Input.GetAxisRaw("Horizontal");
        input.y = Input.GetAxisRaw("Vertical");
        if(input != Vector2.zero)
        {
            lastMoveDirection = input.normalized;
        }
        if(Input.GetKeyDown(KeyCode.LeftShift))
        {
            StartCoroutine(ExecuteDash());
        }
    }
    private void FixedUpdate()
    {
        if (isDashing) return;
        rb.linearVelocity = input * speed;
    }
    private IEnumerator ExecuteDash()
    {
        isDashing = true;
        if (lastMoveDirection == Vector2.zero) lastMoveDirection = Vector2.right;

        rb.linearVelocity = lastMoveDirection * dashSpeed;

        yield return new WaitForSeconds(dashTime);

        isDashing = false;
    }
}
