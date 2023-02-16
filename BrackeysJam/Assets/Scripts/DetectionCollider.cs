using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectionCollider : MonoBehaviour
{
    [SerializeField] EnemyController ec;
    private void OnCollisionEnter2D(Collision2D other) 
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.gameObject.tag == "Player")
        {
            ec.followTarget = other.transform;
        }
    }
}