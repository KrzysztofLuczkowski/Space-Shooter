using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public GameObject mainMenuUI; // Referencja do UI menu g³ównego
    public GameObject inGameUI;   // Referencja do UI Gry (HP/Points)
    public Button playButton;    // Referencja do przycisku Play
    public Button quitButton;    // Referencja do przycisku Quit
    public PlayerController playerController; // Referencja do sterowania gracza

    private void Start()
    {
        // Ustawienie pocz¹tkowego stanu gry
        Time.timeScale = 0f;
        mainMenuUI.SetActive(true); // Pokazujemy menu g³ówne
        playerController.enabled = false; // Wy³¹czamy sterowanie gracza
        inGameUI.SetActive(false);

        // Przypisanie funkcji do przycisków
        playButton.onClick.AddListener(PlayGame);
        quitButton.onClick.AddListener(QuitGame);
    }

    public void PlayGame()
    {
        // Ukryj menu i rozpocznij grê
        mainMenuUI.SetActive(false);
        inGameUI.SetActive(true);
        Time.timeScale = 1f;
        playerController.enabled = true; // W³¹czamy sterowanie gracza
    }

    public void QuitGame()
    {
        Debug.Log("Quit Game");
        Application.Quit();
    }
}
