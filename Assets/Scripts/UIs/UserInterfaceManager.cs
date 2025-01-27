using UnityEngine;
using TMPro;
using System.Collections;
using UnityEngine.SceneManagement;

public class UserInterfaceManager : MonoBehaviour {
    public static UserInterfaceManager instance;

    [Header("In Game References")]
    [SerializeField] internal TextMeshProUGUI scoreText;
    [SerializeField] internal TextMeshProUGUI updateScoreText;
    [SerializeField] internal GameObject UIHeadUpDisplay;
    [SerializeField] internal GameObject UIPaused;
    [SerializeField] internal GameObject UIGameOver;
    [SerializeField] internal GameObject UIResult;
    [SerializeField] internal TextMeshProUGUI UIResultScoreText;
    [SerializeField] internal GameObject UITutorial;

    [Header("Attributes")]
    float showTime = 1f;
    float fadeTime = 1.5f;

    void Awake() {
        instance = this;
    }

    public void UpdateText(TextMeshProUGUI UITextObject, string message) {
        StopCoroutine(FadeOutText(UITextObject, showTime, fadeTime));
        //reset alpha
        Color tmpColor = UITextObject.color;
        UITextObject.color = new Color(tmpColor.r, tmpColor.g, tmpColor.b, 1);
        UITextObject.text = message;
        if (UITextObject == updateScoreText) {
            StartCoroutine(FadeOutText(UITextObject, showTime, fadeTime));
        }
    }

    IEnumerator FadeOutText(TextMeshProUGUI UITextObject, float showTime, float fadeTime) {
        float startAlpha = UITextObject.color.a;
        float rate = 1.0f / fadeTime;
        float progress = 0.0f;
        yield return new WaitForSeconds(showTime);
        while (progress < 1.0) {
            Color tmpColor = UITextObject.color;
            UITextObject.color = new Color(tmpColor.r, tmpColor.g, tmpColor.b, Mathf.Lerp(startAlpha, 0, progress));
            progress += rate * Time.deltaTime;
            yield return null;
        }
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
        SceneManager.LoadScene(sceneName);
    }

    public void LoadSceneViaIndex(int sceneIndex) {
        SceneManager.LoadScene(sceneIndex);
    }

    public void QuitGame() {
        Application.Quit();
    }
}
