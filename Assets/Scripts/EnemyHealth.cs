﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] float hitPoints = 100f;

    // Create a public mthod which reduces hitpoints by the amount of damager
    public void TakeDamage(float damageTaken)
    {
        hitPoints -= damageTaken;
        if (hitPoints <= 0)
            Destroy(gameObject);
    }
}
