using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] float hitPoints = 100f;

    // Create a public mthod which reduces hitpoints by the amount of damager
    public void TakeDamage(float damageTaken)
    {
        //GetComponent<EnemyAI>().OnDamageTaken();
        BroadcastMessage("OnDamageTaken"); //Any class that has this function name on this GO or child will fire
        hitPoints -= damageTaken;
        if (hitPoints <= 0)
        {
            Destroy(gameObject);
        }
    }
}
