using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] float hitPoints = 100f;
    Animator zombieAnimator;
    bool isDead;


    public bool IsDead()
    {
        return isDead;
    }

    private void Start()
    {
        zombieAnimator = GetComponent<Animator>();
    }

    // Create a public mthod which reduces hitpoints by the amount of damager
    public void TakeDamage(float damageTaken)
    {
        //GetComponent<EnemyAI>().OnDamageTaken();
        BroadcastMessage("OnDamageTaken"); //Any class that has this function name on this GO or child will fire
        hitPoints -= damageTaken;
        if (hitPoints <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        if (isDead) return;

        isDead = true;
        zombieAnimator.SetTrigger("dead");
    }
}
