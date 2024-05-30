using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Skor : MonoBehaviour
{  public static int Score = 0;
    public TextMeshProUGUI scoreText; // TMP Text element to display the score
    public FloatingTextEffect floatingTextEffect; // Reference to the FloatingTextEffect script

    private OyuncuKontrol oyuncuKontrol;

    void Start()
    {
        oyuncuKontrol = FindObjectOfType<OyuncuKontrol>();
        UpdateScoreText();
    }

    void Update()
    {
        if (oyuncuKontrol.dogru)
        {
            int scoreChange = 20;
            Score += scoreChange;
            oyuncuKontrol.dogru = false;
            UpdateScoreText();
            floatingTextEffect.ShowFloatingText(scoreChange); // Show floating text
        }
        else if (oyuncuKontrol.yanlis)
        {
            int scoreChange = -4;
            Score += scoreChange;
            oyuncuKontrol.yanlis = false;
            UpdateScoreText();
            floatingTextEffect.ShowFloatingText(scoreChange); // Show floating text
        }
    }

    void UpdateScoreText()
    {
        if (scoreText != null)
        {
            scoreText.text = Score.ToString();
        }
    }
}