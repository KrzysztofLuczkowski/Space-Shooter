using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameOverScreen : MonoBehaviour
{
    public GameObject gameOverUI; // Panel z ekranem Game Over
    public TextMeshProUGUI pointsText; // Tekst wyœwietlaj¹cy punkty

    private ScoreManager scoreManager;

    void Start()
    {
        gameOverUI.SetActive(false); // Ukryj ekran Game Over na pocz¹tku
        scoreManager = FindObjectOfType<ScoreManager>();
    }

    public void ShowGameOver()
    {
        gameOverUI.SetActive(true); // Poka¿ ekran Game Over
        pointsText.text = "Your Points: " + scoreManager.GetScore(); // Wyœwietl punkty
        Time.timeScale = 0f; // Zatrzymaj grê
    }

    public void RestartGame()
    {
        Debug.Log("Restart Scene");
        Time.timeScale = 1f; // Przywróæ grê do normalnego stanu
        string sceneName = "SpaceShooterScene";
        SceneManager.LoadScene(sceneName);
    }
}

