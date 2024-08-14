using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour {
    public TextMeshProUGUI spidersKilled;
    private int score = 0;

    void Start() {
        UpdateScoreUI();
    }

    public void AddScore(int points) {
        score += points;
        UpdateScoreUI();
    }

    private void UpdateScoreUI() {
        if (spidersKilled != null) {
            spidersKilled.text = "Spiders Killed: " + score.ToString();
        }
    }
}