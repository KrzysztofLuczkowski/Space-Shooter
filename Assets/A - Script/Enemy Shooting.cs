using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    public GameObject bulletPrefab;   // Prefab pocisku
    public float fireInterval = 3f;  // Czas mi�dzy strza�ami
    public float bulletSpeed = 1f;   // Pr�dko�� pocisku
    public AudioClip laserShootSound; // D�wi�k lasera przeciwnika
    private AudioSource audioSource;

    private Transform player; // Referencja do gracza

    void Start()
    {
        // Znalezienie gracza po tagu
        player = GameObject.FindGameObjectWithTag("Player").transform;

        // Powtarzaj�ce si� strzelanie
        InvokeRepeating(nameof(FireBullet), 1f, fireInterval);
        audioSource = GetComponent<AudioSource>();
    }

    void FireBullet()
    {
        // Warunek: je�li przeciwnik jest poza X -1, nie strzela
        if (transform.position.x < -1f) return;

        if (player == null) return;

        // Stworzenie pocisku
        GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        audioSource.PlayOneShot(laserShootSound); // Odtw�rz d�wi�k
        // Obliczenie kierunku strza�u (pozycja gracza w momencie strza�u)
        Vector2 direction = (player.position - transform.position).normalized;

        // Nadanie pr�dko�ci pociskowi
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.velocity = direction * bulletSpeed;

        // Obr�cenie pocisku w kierunku lotu
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg; // K�t w stopniach
        bullet.transform.rotation = Quaternion.Euler(0f, 0f, angle + 90f); // Obr�t pocisku
    }
}
