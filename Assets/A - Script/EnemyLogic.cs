using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float moveSpeed = 1f; // Prêdkoœæ ruchu
    private ScoreManager scoreManager;
    public int health = 1;
    public GameObject healthPackPrefab;
    public AudioClip destructionSound; // DŸwiêk zniszczenia
    private AudioSource audioSource;

    void Start()
    {
        scoreManager = FindObjectOfType<ScoreManager>(); // ZnajdŸ ScoreManager w scenie
        audioSource = GetComponent<AudioSource>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        // Kolizja z pociskiem gracza
        if (collision.CompareTag("PlayerBullet"))
        {
            health = health - 1;
            Destroy(collision.gameObject);
            if (health == 0)
            {
                scoreManager.AddPoint(); // Dodaj punkt
                audioSource.PlayOneShot(destructionSound); // Odtwórz dŸwiêk
                GetComponent<Collider2D>().enabled = false;
                foreach (Renderer renderer in GetComponentsInChildren<Renderer>())
                {
                    renderer.enabled = false; // Ukryj obiekt
                }
                Destroy(gameObject, destructionSound.length); // Zniszcz obiekt po zakoñczeniu dŸwiêku

                if (healthPackPrefab != null)
                {
                 Instantiate(healthPackPrefab, transform.position, Quaternion.identity);
                }

            }
        }
        if (collision.CompareTag("Player"))
        {
            
            audioSource.PlayOneShot(destructionSound); // Odtwórz dŸwiêk
            GetComponent<Collider2D>().enabled = false;
            foreach (Renderer renderer in GetComponentsInChildren<Renderer>())
            {
                renderer.enabled = false; // Ukryj obiekt
            }
            Destroy(gameObject, destructionSound.length); // Zniszcz obiekt po zakoñczeniu dŸwiêku

            if (healthPackPrefab != null)
            {
                Instantiate(healthPackPrefab, transform.position, Quaternion.identity);
            }

        }


    }

    void Update()
    {
        // Ruch od prawej do lewej (oœ X)
        transform.Translate(Vector2.up * moveSpeed * Time.deltaTime);

        // Automatyczne usuwanie wroga, gdy wyjdzie poza ekran
        if (transform.position.x < -3f) // Dostosuj wartoœæ dla krawêdzi ekranu
        {
            Destroy(gameObject);
        }
    }
}
