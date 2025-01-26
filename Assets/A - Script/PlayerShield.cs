using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShield : MonoBehaviour
{
    public GameObject shieldVisual; // Obiekt wizualny tarczy

    public bool isShieldActive = false;
    private float shieldTimer = 0f;


    private void Update()
    {
        if (isShieldActive)
        {
            shieldTimer -= Time.deltaTime;

            if (shieldTimer <= 0)
            {
                DeactivateShield();
            }
        }
        
    }   

    public void ActivateShield(float duration)
    {
        isShieldActive = true;
        shieldTimer = duration;
        shieldVisual.SetActive(true); // Poka¿ tarczê
    }

    private void DeactivateShield()
    {
        isShieldActive = false;
        shieldVisual.SetActive(false); // Ukryj tarczê
    }

    
}
