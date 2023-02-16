using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public Transform followTarget;
    public float moveSpeed = 5f;

    Rigidbody2D rb;
    Vector3 heading;

    private void Awake() 
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionStay2D(Collision2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            Health health = other.gameObject.GetComponent<Health>();
            health.takeDamage(1);
        }  
    }

    private void Update() 
    {
        if(followTarget != null)
        {
            heading = followTarget.position - transform.position;
            Debug.DrawRay(transform.position, heading, Color.green);
            heading.Normalize();
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(heading.x * moveSpeed, heading.y * moveSpeed);
    }
}
