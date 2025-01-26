using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float minX = -2f; // Minimalna granica X
    private float maxX = 2f;  // Maksymalna granica X
    private float minY = -1.5f; // Minimalna granica Y
    private float maxY = 1.5f;  // Maksymalna granica Y

    void Update()
    {
        // Sprawdzenie, czy pocisk wyszed³ poza granice
        if (transform.position.x < minX || transform.position.x > maxX ||
            transform.position.y < minY || transform.position.y > maxY)
        {
            Destroy(gameObject); // Usuniêcie pocisku
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        // Sprawdzenie, czy pocisk trafi³ w gracza
        if (other.CompareTag("Player"))
        {
            Destroy(gameObject); // Zniszczenie pocisku po trafieniu w gracza
        }
    }
}
