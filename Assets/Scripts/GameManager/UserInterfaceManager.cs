using UnityEngine;
using TMPro;
using System.Collections;

public class UserInterfaceManager : MonoBehaviour {
    public static UserInterfaceManager instance;

    [Header("References")]
    [SerializeField] internal TextMeshProUGUI scoreText;
    [SerializeField] internal TextMeshProUGUI updateScoreText;

    [Header("Attributes")]
    float showTime = 1f;
    float fadeTime = 1.5f;

    void Awake() {
        instance = this;
    }

    public void UpdateText(TextMeshProUGUI UITextObject, string message) {
        UITextObject.color = new Color(1, 1, 1, 1);
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
}
