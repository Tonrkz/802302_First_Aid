using UnityEngine;
using TMPro;

public class UserInterfaceManager : MonoBehaviour {
    public static UserInterfaceManager instance;

    [Header("References")]
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI updateScoreText;

    void Awake() {
        instance = this;
    }
}
