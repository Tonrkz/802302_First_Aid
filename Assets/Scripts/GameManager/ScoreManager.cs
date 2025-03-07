using System.Collections;
using UnityEngine;

public class ScoreManager : MonoBehaviour {
    public static ScoreManager instance;

    [Header("References")]
    [SerializeField] GameObject wrongStepHUD;

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
        BGMManager.instance.PlayBGMClip(BGMManager.instance.stageFailedBGM);
        UserInterfaceManager.instance.ToggleUI(UserInterfaceManager.instance.UIHeadUpDisplay);
        UserInterfaceManager.instance.ToggleUI(UserInterfaceManager.instance.UIGameOver);
        UserInterfaceManager.instance.FadeinUI(UserInterfaceManager.instance.UIGameOverPanel);
    }

    public void StageCleared() {
        BGMManager.instance.PlayBGMClip(BGMManager.instance.stageClearedBGM);
        UserInterfaceManager.instance.ToggleUI(UserInterfaceManager.instance.UIHeadUpDisplay);
        UserInterfaceManager.instance.ToggleUI(UserInterfaceManager.instance.UIResult);
        UserInterfaceManager.instance.FadeinUI(UserInterfaceManager.instance.UIResultPanel);
        UserInterfaceManager.instance.UpdateText(UserInterfaceManager.instance.UIResultScoreText, $"{score}");
    }

    public IEnumerator ShowWrongStepHUD() {
        wrongStepHUD.SetActive(true);
        wrongStepHUD.GetComponent<Animator>().Play("Anim_WrongStepHUD");
        yield return new WaitForSeconds(2f);
        wrongStepHUD.SetActive(false);
    }
}