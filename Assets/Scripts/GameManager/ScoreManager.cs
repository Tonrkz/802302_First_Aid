using System;
using UnityEngine;

public class ScoreManager : MonoBehaviour {
    public static ScoreManager instance;

    [Header("Attributes")]
    int scorePerStep = 5;
    int minusScorePerStep = 3;
    int comboMultiplier = 5;
    public int score = 10;
    public int deltaScore = 0;
    int combo = 0;

    void Awake() {
        instance = this;
    }

    void Start() {
        string fourDigitScore = score.ToString("D4");
        UserInterfaceManager.instance.UpdateText(UserInterfaceManager.instance.scoreText, $"{fourDigitScore}");
    }

    public void PerfectBeat() {
        deltaScore = 3;
        score += deltaScore;
        string fourDigitScore = score.ToString("D4");
        UserInterfaceManager.instance.UpdateText(UserInterfaceManager.instance.scoreText, $"{fourDigitScore}");
        UserInterfaceManager.instance.UpdateText(UserInterfaceManager.instance.updateScoreText, $"+{deltaScore} Perfect!");
    }

    public void GoodBeat() {
        deltaScore = 2;
        score += deltaScore;
        string fourDigitScore = score.ToString("D4");
        UserInterfaceManager.instance.UpdateText(UserInterfaceManager.instance.scoreText, $"{fourDigitScore}");
        UserInterfaceManager.instance.UpdateText(UserInterfaceManager.instance.updateScoreText, $"+{deltaScore} Good!");
    }

    public void MissedBeat() {
        deltaScore = -2;
        score += deltaScore;
        string fourDigitScore = score.ToString("D4");
        UserInterfaceManager.instance.UpdateText(UserInterfaceManager.instance.scoreText, $"{fourDigitScore}");
        UserInterfaceManager.instance.UpdateText(UserInterfaceManager.instance.updateScoreText, $"{deltaScore} Missed!");
    }

    public void AddScore() {
        deltaScore = scorePerStep + combo * comboMultiplier;
        score += deltaScore;
        combo++;
        string fourDigitScore = score.ToString("D4");
        UserInterfaceManager.instance.UpdateText(UserInterfaceManager.instance.scoreText, $"{fourDigitScore}");
    }

    public void SubtractScore() {
        score -= minusScorePerStep;
        combo = 0;
        string fourDigitScore = score.ToString("D4");
        UserInterfaceManager.instance.UpdateText(UserInterfaceManager.instance.scoreText, $"{fourDigitScore}");
        UserInterfaceManager.instance.UpdateText(UserInterfaceManager.instance.updateScoreText, "-3 Wrong");
    }
}
