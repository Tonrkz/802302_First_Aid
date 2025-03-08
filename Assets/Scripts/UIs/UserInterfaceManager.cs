using UnityEngine;
using TMPro;
using System.Collections;
using UnityEngine.SceneManagement;
using DG.Tweening;
using Unity.VisualScripting;

public class UserInterfaceManager : MonoBehaviour {
    public static UserInterfaceManager instance;

    [Header("In Game References")]
    [SerializeField] internal TextMeshProUGUI scoreText;
    [SerializeField] internal TextMeshProUGUI updateScoreText;
    [SerializeField] internal GameObject UIHeadUpDisplay;
    [SerializeField] internal GameObject UIPaused;
    [SerializeField] internal GameObject UIGameOver;
    [SerializeField] internal GameObject UIGameOverPanel;
    [SerializeField] internal GameObject UIResult;
    [SerializeField] internal GameObject UIResultPanel;
    [SerializeField] internal TextMeshProUGUI UIResultScoreText;
    [SerializeField] internal GameObject UITutorial;

    [Header("Attributes")]
    float fadeTime = 1.5f;

    void Awake() {
        instance = this;
    }

    public void UpdateText(TextMeshProUGUI UITextObject, string message) {
        //StopCoroutine("FadeOutText");
        ////reset alpha
        //UITextObject.DOKill(true);
        //UITextObject.DOFade(1, 0);
        UITextObject.text = message;
        //if (UITextObject == updateScoreText) {
        //    StartCoroutine(FadeOutText(UITextObject, showTime, fadeTime));
        //}
    }

    public void PlaySFXOnUI(AudioClip audioClip) {
        SFXManager.instance.PlaySFXClip(audioClip, transform, 1f);
    }

    public void ScaleUpUI(GameObject ui) {
        ui.transform.localScale = new Vector3(1.1f, 1.1f, 1.1f);
    }

    public void ScaleDownUI(GameObject ui) {
        ui.transform.localScale = new Vector3(1f, 1f, 1f);
    }

    public void ToggleUI(GameObject ui) {
        ui.SetActive(!ui.activeSelf);
    }

    public void PauseGame() {
        Time.timeScale = 0;
    }

    public void ResumeGame() {
        Time.timeScale = 1;
    }

    public void LoadSceneViaName(string sceneName) {
        if (sceneName == "TitleScene") {
            PlayerPrefs.SetInt("BackToLevelSelection", 1);
            SceneManager.LoadScene(sceneName);
        }
        else {
            SceneManager.LoadScene(sceneName);
        }
    }

    public void LoadSceneViaIndex(int sceneIndex) {
        SceneManager.LoadScene(sceneIndex);
    }

    public void QuitGame() {
        Application.Quit();
    }

    public void FadeinUI(GameObject ui) {
        ui.GetComponent<CanvasGroup>().DOFade(1, fadeTime);
    }

    public void FadeOutUI(GameObject ui) {
        ui.GetComponent<CanvasGroup>().DOFade(0, fadeTime);
    }

    public void FadeTint(GameObject obj, Color color) {
        obj.GetComponent<SpriteRenderer>().DOColor(color, fadeTime);
    }
}
