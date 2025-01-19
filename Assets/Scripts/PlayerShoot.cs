using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public IWeapon currentWeapon;
    public IWeapon meleeWeapon;
    [SerializeField] private TextMeshProUGUI weaponName;
    [SerializeField] private TextMeshProUGUI weaponAmmo;
    [SerializeField] private TextMeshProUGUI reloadWeapon;
    void Start()
    {
        EquipWeapon(gameObject.AddComponent<Pistol>());
        MeleeWeapon(gameObject.AddComponent<Punch>());
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T)) {
            meleeWeapon.Fire();
        }
        if (Input.GetButtonDown("Fire1") && currentWeapon.GetType().Name != "Uzi")
        {
            currentWeapon.Fire();
        }
        //El como se dispara no deberia estar aqui, si es distinto para cada arma deberian ser metodos de la interfaz o de la clase abstracta.
        if (Input.GetButton("Fire1") && currentWeapon.GetType().Name == "Uzi")
        {
            currentWeapon.Fire();
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            currentWeapon.Reload();
        }

        if (currentWeapon != null)
        {
            weaponName.text = currentWeapon.GetType().Name;
        }
        
        if (currentWeapon is Weapons weapon)
        {
            weaponAmmo.text = weapon.CurrentAmmo.ToString();
            if (weapon.CurrentAmmo == 0)
            {
                reloadWeapon.text = "Presh R to reload";
            } else
            {
                reloadWeapon.text = "";
            }
        }
    }
    public void EquipWeapon(IWeapon weapon)
    {
        currentWeapon = weapon;
        Debug.Log($"Equipped {currentWeapon.GetType().Name}"); 
    }
    public void MeleeWeapon(IWeapon weapon)
    {
        meleeWeapon = weapon;
    }
}
