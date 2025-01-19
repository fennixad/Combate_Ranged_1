using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Pistol : Weapons, IWeapon
{
    public Pistol()
    {
        Name = "Pistol";
        Damage = 1;
        FireRate = 0.5f;
        ReloadTime = 2.0f;
        MaxAmmo = 6;
        CurrentAmmo = MaxAmmo;
    }

    protected override void PerformFire()
    {
        if (CurrentAmmo <= 0)
        {
            return;
        }

        CurrentAmmo--;

        // Raycast para simular el disparo
        Ray ray = new(transform.position, transform.forward);

        if (Physics.Raycast(ray, out RaycastHit hit, 30f))
        {
            EnemyController enemyController = hit.collider.GetComponent<EnemyController>();
            if (enemyController != null)
            {
                enemyController.TakingDmg(Damage);
            }
        }
    }

    public void Reload()
    {
        if (IsReloading) return;

        StartCoroutine(ReloadCoroutine());
    }

    public void DisplayName()
    {
        textWeaponName.text = Name;
    }

    public void DisplayAmmo()
    {
        textAmmo.text = CurrentAmmo.ToString();
    }
}