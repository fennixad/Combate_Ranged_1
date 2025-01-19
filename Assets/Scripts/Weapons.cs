using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public abstract class Weapons : MonoBehaviour
{
    public string Name { get; protected set; }
    public int Damage { get; protected set; }
    public float FireRate { get; protected set; }
    public int MaxAmmo { get; protected set; }
    public int CurrentAmmo { get; protected set; }
    public float ReloadTime { get; protected set; }
    public TextMeshProUGUI textWeaponName;
    public TextMeshProUGUI textAmmo;
    protected bool CanShoot { get; set; } = true;
    protected bool IsReloading { get; private set; } = false;
    private bool _isCooldownActive = false;

    public void Fire()
    {
        // No se puede disparar si está recargando o si está en cooldown
        if (IsReloading || !CanShoot || _isCooldownActive)
        {
            return;
        }

        // Realiza el disparo
        PerformFire();

        // Empieza el cooldown
        StartCooldown();
    }

    // Este método se sobrescribirá en las subclases para manejar el disparo
    protected abstract void PerformFire();

    // Inicia el cooldown
    private void StartCooldown()
    {
        _isCooldownActive = true;
        CanShoot = false;
        StartCoroutine(CooldownCoroutine());
    }

    // Corutina que maneja el tiempo de espera del cooldown
    private IEnumerator CooldownCoroutine()
    {
        yield return new WaitForSeconds(FireRate);
        ResetCooldown();
    }

    // Restablece el cooldown
    private void ResetCooldown()
    {
        _isCooldownActive = false;
        CanShoot = true;
    }

    // Métodos protegidos opcionales para manejar recarga
    protected void SetReloading(bool reloading)
    {
        IsReloading = reloading;
    }

    public IEnumerator ReloadCoroutine()
    {
        SetReloading(true);
        yield return new WaitForSeconds(ReloadTime);
        CurrentAmmo = MaxAmmo;
        SetReloading(false);
    }
}
