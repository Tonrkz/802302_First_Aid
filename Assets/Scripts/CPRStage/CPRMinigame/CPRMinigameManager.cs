using UnityEngine;

public class CPRMinigameManager : MonoBehaviour {
    public static CPRMinigameManager instance;

    void Awake() {
        instance = this;
    }
}
