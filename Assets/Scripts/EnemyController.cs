using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private readonly int hitpoints = 100;
    private int currentHitpoints;
    public TextMeshProUGUI textMeshProUGUI;

    void Start()
    {
        if (textMeshProUGUI == null)
        {
            Debug.LogError("El componente TextMeshProUGUI no está asignado. Verifica que esté asignado en el Inspector.");
            return;
        }

        currentHitpoints = hitpoints;
        UpdateHealthDisplay();
    }

    public void TakingDmg(int dmg)
    {
        currentHitpoints -= dmg;
        currentHitpoints = Mathf.Max(currentHitpoints, 0);
        UpdateHealthDisplay();

        if (currentHitpoints <= 0)
        {
            Death();
        }
    }
    
    private void UpdateHealthDisplay()
    {
        textMeshProUGUI.text = currentHitpoints.ToString();
        UpdateColorDisplay();
    }

    private void UpdateColorDisplay()
    {
        if (currentHitpoints <= 40)
        {
            textMeshProUGUI.color = Color.red;
        }
        else if (currentHitpoints > 40 && currentHitpoints <= 70)
        {
            textMeshProUGUI.color = Color.yellow; 
        }
        else
        {
            textMeshProUGUI.color = Color.green; 
        }
    }
    private void Death()
    {
        Debug.Log("Muerto");
        //Destroy(gameObject);
    }
}