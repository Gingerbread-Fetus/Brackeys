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
    float lastXDirection, lastYDirection;

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
            lastXDirection = moveDirection.x;
            lastYDirection = moveDirection.y;
            animator.SetFloat("Last X Direction", lastXDirection);
            animator.SetFloat("Last Y Direction", lastYDirection);
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);
    }

    public void Fire(InputAction.CallbackContext context)
    {
        animator.SetTrigger("Attack");
        Debug.DrawRay(transform.position, new Vector3(lastXDirection, lastYDirection, 0), Color.red, 10f);
        RaycastHit2D hit = Physics2D.Raycast(transform.position, new Vector2(lastXDirection, lastYDirection), 1f);
        if(hit.collider != null)
        {
            print("Hit something");
            print(hit.collider.name);
        }
    }
}
