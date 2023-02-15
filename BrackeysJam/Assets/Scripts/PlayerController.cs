using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public InputAction moveControls;
    public InputAction fireAction;

    Rigidbody2D rb;
    Vector2 moveDirection;
    Animator animator;

    private void OnEnable()
    {
        moveControls.Enable();
        fireAction.Enable();
    }

    private void OnDisable() 
    {
        moveControls.Disable();
        fireAction.Disable();    
    }

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        fireAction.performed += Fire;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        moveDirection = moveControls.ReadValue<Vector2>();
        animator.SetFloat("X Direction", moveDirection.x);
        animator.SetFloat("Y Direction", moveDirection.y);

        if(moveDirection.x == 1f || moveDirection.x == -1f ||
           moveDirection.y == 1f || moveDirection.y == -1f)
        {
            animator.SetFloat("Last X Direction", moveDirection.x);
            animator.SetFloat("Last Y Direction", moveDirection.y);
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);
    }

    public void Fire(InputAction.CallbackContext context)
    {
        animator.SetTrigger("Attack");
    }
}
