using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        // Sprawdzenie, czy laser trafi� w obiekt oznaczony jako wr�g
        if (collision.CompareTag("Enemy"))
        {
            // Zniszczenie lasera
            Destroy(gameObject);
        }
    }

    void Update()
    {
        // Automatyczne niszczenie lasera po opuszczeniu ekranu
        if (transform.position.x > 2f)
        {
            Destroy(gameObject);
        }
    }
}
