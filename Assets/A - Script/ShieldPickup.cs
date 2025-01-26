using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldPickup : MonoBehaviour
{
    public float speed = 1f; // Prêdkoœæ tarczy

    private void Update()
    {
        // Ruch tarczy w lewo
        transform.Translate(Vector2.left * speed * Time.deltaTime);

        // Zniszczenie tarczy po opuszczeniu ekranu
        if (transform.position.x < -2f)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerShield playerShield = other.GetComponent<PlayerShield>();
            Debug.Log("SHIELD PICKUP");

            if (playerShield != null)
            {
                playerShield.ActivateShield(5f); // Aktywacja tarczy na 5 sekund
                Destroy(gameObject);
            }
        }
    }
}
