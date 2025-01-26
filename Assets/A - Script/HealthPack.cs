using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPack : MonoBehaviour
{
    public float speed = 2f; // Prêdkoœæ apteczki

    private void Update()
    {
        // Ruch apteczki w lewo
        transform.Translate(Vector2.left * speed * Time.deltaTime);

        // Zniszczenie apteczki po opuszczeniu ekranu
        if (transform.position.x < -2f)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();

            // Leczenie gracza
            if (playerHealth != null && playerHealth.currentHealth < 3)
            {
                Debug.Log("APTECZKA ZEBRANA");
                playerHealth.currentHealth = playerHealth.currentHealth + 1;
                Debug.Log(playerHealth.currentHealth);
                playerHealth.UpdateHealthUI();
                Destroy(gameObject);
            }
        }
    }
}
