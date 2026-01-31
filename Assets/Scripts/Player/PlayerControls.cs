using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Tilemaps;

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
    public Player_Combat player_combat;
    Animator anim;
    private bool facingDown = true;



    InputAction _interact;


    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        _interact = InputSystem.actions.FindAction("Interact");
    }

    // Update is called once per frame
    void Update()
    {
        if (isDashing) return;

        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");
        input.x = Input.GetAxisRaw("Horizontal");
        input.y = Input.GetAxisRaw("Vertical");
        if((moveX == 0 && moveY == 0) &&  (input.x != 0 || input.y != 0))
        {
            lastMoveDirection = input;
        }
        if(input != Vector2.zero)
        {
            lastMoveDirection = input.normalized;
        }
        if(Input.GetKeyDown(KeyCode.LeftShift))
        {
            StartCoroutine(ExecuteDash());
        }
        if (Input.GetMouseButtonDown(0)){
            player_combat.Attack();
        }
        if (_interact.WasPressedThisFrame())
        {
            Interact();
        }
        Animate();

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
    void Animate()
    {
        anim.SetFloat("MoveX", input.x);
        anim.SetFloat("MoveY", input.y);
        anim.SetFloat("MoveMagnitude", input.magnitude);
        anim.SetFloat("LastMoveX", lastMoveDirection.x);
        anim.SetFloat("LastMoveY", lastMoveDirection.y);
    }

    private void Interact()
    {
        if (!GameManager.Instance.Interactable) return;
        if (!GameManager.Instance.Interactable.TryGetComponent(out IInteractable interactable)) return;
        interactable.Interact();
    }
}
