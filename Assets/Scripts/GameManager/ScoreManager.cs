using NUnit.Framework;
using System;
using UnityEngine;

public class ScoreManager : MonoBehaviour {
    public static ScoreManager instance;

    [Header("Attributes")]
    int scorePerStep = 5;
    int minusScorePerStep = 3;
    int comboMultiplier = 5;
    int score = 10;
    int combo = 0;
    Byte step = 0;

    void Awake() {
        instance = this;
    }

    public void AddScore() {
        score += scorePerStep + combo * comboMultiplier;
        combo++;
    }

    public void SubtractScore() {
        score -= minusScorePerStep;
        combo = 0;
    }
}
