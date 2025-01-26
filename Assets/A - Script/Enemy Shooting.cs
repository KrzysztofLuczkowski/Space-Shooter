using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    public GameObject bulletPrefab;   // Prefab pocisku
    public float fireInterval = 3f;  // Czas miêdzy strza³ami
    public float bulletSpeed = 1f;   // Prêdkoœæ pocisku
    public AudioClip laserShootSound; // DŸwiêk lasera przeciwnika
    private AudioSource audioSource;

    private Transform player; // Referencja do gracza

    void Start()
    {
        // Znalezienie gracza po tagu
        player = GameObject.FindGameObjectWithTag("Player").transform;

        // Powtarzaj¹ce siê strzelanie
        InvokeRepeating(nameof(FireBullet), 1f, fireInterval);
        audioSource = GetComponent<AudioSource>();
    }

    void FireBullet()
    {
        // Warunek: jeœli przeciwnik jest poza X -1, nie strzela
        if (transform.position.x < -1f) return;

        if (player == null) return;

        // Stworzenie pocisku
        GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        audioSource.PlayOneShot(laserShootSound); // Odtwórz dŸwiêk
        // Obliczenie kierunku strza³u (pozycja gracza w momencie strza³u)
        Vector2 direction = (player.position - transform.position).normalized;

        // Nadanie prêdkoœci pociskowi
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.velocity = direction * bulletSpeed;

        // Obrócenie pocisku w kierunku lotu
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg; // K¹t w stopniach
        bullet.transform.rotation = Quaternion.Euler(0f, 0f, angle + 90f); // Obrót pocisku
    }
}
