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

    [Header("Audio")]
    [SerializeField] AudioClip stageClearedSFX;
    [SerializeField] AudioClip stageFailedSFX;

    void Awake() {
        instance = this;
    }

    void Start() {
        string fourDigitScore = score.ToString("D3");
        UserInterfaceManager.instance.UpdateText(UserInterfaceManager.instance.scoreText, $"{fourDigitScore}");
    }

    public void PerfectBeat() {
        deltaScore = 3;
        score += deltaScore;
        string fourDigitScore = score.ToString("D3");
        UserInterfaceManager.instance.UpdateText(UserInterfaceManager.instance.scoreText, $"{fourDigitScore}");
        UserInterfaceManager.instance.UpdateText(UserInterfaceManager.instance.updateScoreText, $"+{deltaScore} กดหน้าอกถูกจังหวะอย่างมาก!");
    }

    public void GoodBeat() {
        deltaScore = 2;
        score += deltaScore;
        string fourDigitScore = score.ToString("D3");
        UserInterfaceManager.instance.UpdateText(UserInterfaceManager.instance.scoreText, $"{fourDigitScore}");
        UserInterfaceManager.instance.UpdateText(UserInterfaceManager.instance.updateScoreText, $"+{deltaScore} กดหน้าอกถูกจังหวะ!");
    }

    public void MissedBeat() {
        deltaScore = -2;
        score += deltaScore;
        string fourDigitScore = score.ToString("D3");
        UserInterfaceManager.instance.UpdateText(UserInterfaceManager.instance.scoreText, $"{fourDigitScore}");
        UserInterfaceManager.instance.UpdateText(UserInterfaceManager.instance.updateScoreText, $"{deltaScore} กดหน้าอกผิดจังหวะ!");
    }

    public void AddScore() {
        deltaScore = scorePerStep + combo * comboMultiplier;
        score += deltaScore;
        combo++;
        string fourDigitScore = score.ToString("D3");
        UserInterfaceManager.instance.UpdateText(UserInterfaceManager.instance.scoreText, $"{fourDigitScore}");
    }

    public void SubtractScore() {
        score -= minusScorePerStep;
        combo = 0;
        string fourDigitScore = score.ToString("D3");
        UserInterfaceManager.instance.UpdateText(UserInterfaceManager.instance.scoreText, $"{fourDigitScore}");
        UserInterfaceManager.instance.UpdateText(UserInterfaceManager.instance.updateScoreText, "-3 ผิด");
        if (score <= 0) {
            GameOver();
        }
    }

    public void GameOver() {
        SFXManager.instance.PlaySFXClip(stageFailedSFX, transform, 1f);
        UserInterfaceManager.instance.ToggleUI(UserInterfaceManager.instance.UIHeadUpDisplay);
        UserInterfaceManager.instance.ToggleUI(UserInterfaceManager.instance.UIGameOver);
    }

    public void StageCleared() {
        SFXManager.instance.PlaySFXClip(stageClearedSFX, transform, 1f);
        UserInterfaceManager.instance.ToggleUI(UserInterfaceManager.instance.UIHeadUpDisplay);
        UserInterfaceManager.instance.ToggleUI(UserInterfaceManager.instance.UIResult);
        UserInterfaceManager.instance.UpdateText(UserInterfaceManager.instance.UIResultScoreText, $"{score}");
    }
}