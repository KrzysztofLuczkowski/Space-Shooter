using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameOverScreen : MonoBehaviour
{
    public GameObject gameOverUI; // Panel z ekranem Game Over
    public TextMeshProUGUI pointsText; // Tekst wy�wietlaj�cy punkty

    private ScoreManager scoreManager;

    void Start()
    {
        gameOverUI.SetActive(false); // Ukryj ekran Game Over na pocz�tku
        scoreManager = FindObjectOfType<ScoreManager>();
    }

    public void ShowGameOver()
    {
        gameOverUI.SetActive(true); // Poka� ekran Game Over
        pointsText.text = "Your Points: " + scoreManager.GetScore(); // Wy�wietl punkty
        Time.timeScale = 0f; // Zatrzymaj gr�
    }

    public void RestartGame()
    {
        Debug.Log("Restart Scene");
        Time.timeScale = 1f; // Przywr�� gr� do normalnego stanu
        string sceneName = "SpaceShooterScene";
        SceneManager.LoadScene(sceneName);
    }
}

