using UnityEngine;

public class CPR_Beat : MonoBehaviour {
    internal float tempo = 120;

    void Start() {
        tempo /= 60;
    }

    void Update() {
        transform.position -= new Vector3(tempo * Time.deltaTime, 0, 0);
    }

    internal void OnPerfectTrigger() {
        Destroy(gameObject);
    }

    internal void OnGoodTrigger() {
        Destroy(gameObject);
    }

    internal void OnMissedTrigger() {
        Destroy(gameObject);
    }
}
