using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] Camera FPCamera; //We want the camera since that is the center of the screen
    [SerializeField] ParticleSystem muzzleFlash;
    [SerializeField] Ammo ammoSlot;
    [SerializeField] float range = 100;
    [SerializeField] float damage = 30f;

    public GameObject hitEffect;

    private void Update()
    {
        if(Input.GetButtonDown("Fire"))
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        if (ammoSlot.GetCurrentAmmo() > 0)
        {
            PlayMuzzleFlash();
            ProcessRayCast();
            ammoSlot.ReduceCurrentAmmo();
        }
    }

    private void PlayMuzzleFlash()
    {
        muzzleFlash.Play();
    }

    private void ProcessRayCast()
    {
        RaycastHit hit;
        if (Physics.Raycast(FPCamera.transform.position, FPCamera.transform.forward, out hit, range))
        {
            //TODO: Add some hit effect for visual players
            CreateHitImpact(hit);
            EnemyHealth target = hit.transform.GetComponent<EnemyHealth>();
            if (target == null) { return; }
            target.TakeDamage(damage);
            //TODO: Call a method on EnemyHealth that decreases the enemy's health
        }
        else
        {
            return;
        }
    }

    private void CreateHitImpact(RaycastHit hit)
    {
        var impact = Instantiate(hitEffect, hit.point, Quaternion.LookRotation(hit.normal)); //It will be shooting out of its surface away from the obj
        Destroy(impact, .1f); //We have this match the duration of the particle effect
    }
}
