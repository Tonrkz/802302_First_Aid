using UnityEngine;
using TMPro;

public class UserInterfaceManager : MonoBehaviour {
    public static UserInterfaceManager instance;

    [Header("References")]
    [SerializeField] internal TextMeshProUGUI scoreText;
    [SerializeField] internal TextMeshProUGUI updateScoreText;

    void Awake() {
        instance = this;
    }

    public void UpdateText(TextMeshProUGUI UITextObject, string message) {
        UITextObject.text = message;
    }
}
