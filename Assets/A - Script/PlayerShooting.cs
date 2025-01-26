using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public GameObject laserPrefab; // Prefab lasera
    public Transform firePoint;    // Punkt wystrza³u
    public float laserSpeed = 5f; // Prêdkoœæ lasera
    public float fireRate = 1f;     // Czas miêdzy strza³ami (sekundy)
    private float nextFireTime = 0f;
    public AudioClip laserShootSound; // DŸwiêk lasera
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        // Sprawdzenie, czy gracz nacisn¹³ spacjê
        if (Input.GetKeyDown(KeyCode.Space) && Time.time >= nextFireTime)
        {
            Shoot();
            nextFireTime = Time.time + fireRate; // Ustaw czas na nastêpny strza³
        }
    }

    void Shoot()
    {
        // Tworzenie lasera z odpowiedni¹ rotacj¹
        GameObject laser = Instantiate(laserPrefab, firePoint.position, Quaternion.Euler(0, 0, -90));
        audioSource.PlayOneShot(laserShootSound);
        // Nadanie mu prêdkoœci
        Rigidbody2D rb = laser.GetComponent<Rigidbody2D>();
        rb.velocity = Vector2.right * laserSpeed;
    }

}
