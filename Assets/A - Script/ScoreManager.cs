using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public TMP_Text scoreText; // Referencja do Textu punkt�w
    private int score = 0;     // Pocz�tkowa liczba punkt�w

    public void AddPoint()
    {
        score++;
        UpdateScoreUI();
    }

    void UpdateScoreUI()
    {
        scoreText.text = "Points: " + score;
    }

    public int GetScore()
    {
        return score;
    }


}

