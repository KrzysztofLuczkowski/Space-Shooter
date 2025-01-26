using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 3; // Startowe Maksymalne zdrowie
    public int currentHealth;
    public GameObject[] healthSegments; // Obrazy segmentów ¿ycia
    public PlayerShield PlayerShield;

    void Start()
    {
        currentHealth = maxHealth; // Ustawienie zdrowia na maksymalne
        Debug.Log("Starting health: " + currentHealth); // Debugowanie pocz¹tkowego zdrowia
        UpdateHealthUI(); // Zaktualizowanie paska zdrowia
    }



    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.CompareTag("EnemyBullet"))
        {
            
            if (PlayerShield.isShieldActive == false) // Jeœli mamy tarczê to ignorujemy obra¿enia
            {
              TakeDamage(); // Gracz traci zdrowie
            }
            Destroy(other.gameObject); // Zniszczenie pocisku
        }

        if (other.CompareTag("Enemy"))
        {
            
            if (PlayerShield.isShieldActive == false) // Jeœli mamy tarczê to ignorujemy obra¿enia
            {
                TakeDamage(); // Gracz traci zdrowie
            }
            
        }
    }


    void TakeDamage()
    {
        if (currentHealth > 0)
        {
            currentHealth--;
            Debug.Log("Player took damage"); // Debugowanie zmiany zdrowia
            UpdateHealthUI(); // Zaktualizowanie UI
        }

        if (currentHealth <= 0)
        {
            FindObjectOfType<GameOverScreen>().ShowGameOver(); // Poka¿ ekran Game Over
            

        }
    }



    public void UpdateHealthUI()
    {

        // Upewniamy siê, ¿e aktywujemy/dezaktywujemy segmenty paska zdrowia w zale¿noœci od currentHealth
        for (int i = 0; i < healthSegments.Length; i++)
        {
            if (i < currentHealth)
            {
                if (!healthSegments[i].activeSelf) // Sprawdzenie, czy segment jest ju¿ aktywowany
                {
                    Debug.Log("Activating health segment " + i);
                    healthSegments[i].SetActive(true); // Aktywowanie segmentu
                }
            }
            else
            {
                if (healthSegments[i].activeSelf) // Sprawdzenie, czy segment jest aktywny, aby go dezaktywowaæ
                {
                    Debug.Log("Deactivating health segment " + i);
                    healthSegments[i].SetActive(false); // Dezaktywowanie segmentu
                }
            }
        }
    }
}
