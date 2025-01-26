using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public GameObject laserPrefab; // Prefab lasera
    public Transform firePoint;    // Punkt wystrza�u
    public float laserSpeed = 5f; // Pr�dko�� lasera
    public float fireRate = 1f;     // Czas mi�dzy strza�ami (sekundy)
    private float nextFireTime = 0f;
    public AudioClip laserShootSound; // D�wi�k lasera
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        // Sprawdzenie, czy gracz nacisn�� spacj�
        if (Input.GetKeyDown(KeyCode.Space) && Time.time >= nextFireTime)
        {
            Shoot();
            nextFireTime = Time.time + fireRate; // Ustaw czas na nast�pny strza�
        }
    }

    void Shoot()
    {
        // Tworzenie lasera z odpowiedni� rotacj�
        GameObject laser = Instantiate(laserPrefab, firePoint.position, Quaternion.Euler(0, 0, -90));
        audioSource.PlayOneShot(laserShootSound);
        // Nadanie mu pr�dko�ci
        Rigidbody2D rb = laser.GetComponent<Rigidbody2D>();
        rb.velocity = Vector2.right * laserSpeed;
    }

}
