using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class WeaponSelector : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 50f; // Velocidad de rotación del arma
    [SerializeField] private string weaponType; // Prefab del arma para equipar

    private bool isPickedUp = false;

    void Update()
    {
        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!isPickedUp && other.CompareTag("Player"))
        {
            EquipWeapon(other.gameObject);
        }
    }

    private void EquipWeapon(GameObject player)
    {
        PlayerShoot playerShoot = player.GetComponent<PlayerShoot>();
        if (playerShoot != null)
        {
           RemoveOtherWeapons(player);

            // Instancia el arma según el tipo configurado
            IWeapon newWeapon = CreateWeapon(player);
            if (newWeapon != null)
            {
                playerShoot.EquipWeapon(newWeapon);
            }
        }
    }

    private IWeapon CreateWeapon(GameObject player)
    {
        // Crea un arma específica según el tipo
        switch (weaponType.ToLower())
        {
            case "pistol":
                return (IWeapon)player.AddComponent<Pistol>();
            case "uzi":
                return (IWeapon)player.AddComponent<Uzi>();
            case "shotgun":
                return (IWeapon)player.AddComponent<Rifle>();
            default:
                return null;
        }
    }
        private void RemoveOtherWeapons(GameObject player)
    {
        if (weaponType.ToLower() != "pistol")
        {
            Destroy(player.GetComponent<Pistol>());
        }
        if (weaponType.ToLower() != "uzi")
        {
            Destroy(player.GetComponent<Uzi>());
        }
        if (weaponType.ToLower() != "rifle")
        {
            Destroy(player.GetComponent<Rifle>());
        }
    }
}
