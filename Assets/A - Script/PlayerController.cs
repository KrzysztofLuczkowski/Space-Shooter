using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 1f;

    void Update()
    {
        // Pobranie inputu gracza (góra/dó³)
        float moveVertical = Input.GetAxis("Vertical");

        // Ruch statku w górê i w dó³ (oœ Y)
        float newYPosition = transform.position.y + moveVertical * moveSpeed * Time.deltaTime;

        // Ograniczenie pozycji statku na osi Y
        newYPosition = Mathf.Clamp(newYPosition, -0.9f, 0.9f);

        // Ustawienie nowej pozycji statku
        transform.position = new Vector3(transform.position.x, newYPosition, transform.position.z);
    }
}
