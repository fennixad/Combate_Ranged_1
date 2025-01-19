using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using UnityEngine;

public class Punch : Weapons, IWeapon
{
    public Punch()
    {
        Name = "Punch";
        Damage = 15;
        FireRate = 2.0f;
        ReloadTime = 3.0f;
        MaxAmmo = 1000;
        CurrentAmmo = MaxAmmo;
    }
    protected override void PerformFire()
    {
        // Raycast para simular el disparo
        Ray ray = new(transform.position, transform.forward);

        if (Physics.Raycast(ray, out RaycastHit hit, 2f))
        {
            EnemyController enemyController = hit.collider.GetComponent<EnemyController>();
            if (enemyController != null)
            {
                enemyController.TakingDmg(Damage);
            }
        }
    }
    public void DisplayName()
    {
        textWeaponName.text = Name;
    }

    public void Reload()
    {
        throw new System.NotImplementedException();
    }

    public void DisplayAmmo()
    {
        throw new System.NotImplementedException();
    }
}