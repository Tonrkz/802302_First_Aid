using UnityEngine;

public class CPR_BeatScroller : MonoBehaviour {
    internal float tempo = 120;

    void Start() {
        tempo /= 60;
    }

    void Update() {
        transform.position -= new Vector3(tempo * Time.deltaTime, 0, 0);
    }
}
