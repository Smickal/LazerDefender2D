using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;


public class UIDisplay : MonoBehaviour
{
    [SerializeField] Slider healthSlider;
    [SerializeField] TextMeshProUGUI scoreText;

    ScoreKeeper scoreKeeper;
    [SerializeField] Health playerHealth;

    int currentHP;
    float currentScore;

    private void Awake()
    {
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
        currentHP = playerHealth.GetCurrentHP();
    }

    private void Start()
    {
        healthSlider.maxValue = currentHP;
        healthSlider.value = currentHP;
    }
    private void Update()
    {
        UpdateCurrentScore();
        UpdatePlayerHP();
    }

    void UpdatePlayerHP()
    {
        currentHP = playerHealth.GetCurrentHP();
        healthSlider.value = currentHP;
    }

    void UpdateCurrentScore()
    {
        currentScore = scoreKeeper.GetCurrentScore();
        scoreText.text = currentScore.ToString("000000000");
    }

}
