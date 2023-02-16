using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int healthPoints = 5;
    public float invincibilityTime = 5f;

    private bool isInvincible = false;
    
    private void Update() 
    {

    }

    public void takeDamage(int damage)
    {
        if(isInvincible) return;

        healthPoints -= damage;
        if(healthPoints <= 0)
        {
            Die();
            return;
        }

        StartCoroutine(BecomeTemporarilyInvincible());
    }

    private IEnumerator BecomeTemporarilyInvincible()
    {
        isInvincible = true;

        yield return new WaitForSeconds(invincibilityTime);

        isInvincible = false;
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}
