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
        Debug.Log("Perfect");
        ScoreManager.instance.PerfectBeat();
        CPRMinigameManager.instance.beatTriggered++;
        Destroy(gameObject);
    }

    internal void OnGoodTrigger() {
        Debug.Log("Good");
        ScoreManager.instance.GoodBeat();
        CPRMinigameManager.instance.beatTriggered++;
        Destroy(gameObject);
    }

    internal void OnMissedTrigger() {
        Debug.Log("Missed");
        CPRMinigameManager.instance.MissedBeat();
        ScoreManager.instance.MissedBeat();
        Destroy(gameObject);
    }
}
