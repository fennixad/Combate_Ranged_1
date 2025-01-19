using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Uzi : Weapons, IWeapon
{
    public Uzi()
    {
        Name = "Uzi";
        Damage = 2;
        FireRate = 0.1f;
        ReloadTime = 2.5f;
        MaxAmmo = 30;
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
