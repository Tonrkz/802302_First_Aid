using UnityEngine;

public class CPR_Beat : MonoBehaviour {
    [Header("Attributes")]
    internal float tempo = 120;

    [Header("Audio")]
    [SerializeField] AudioClip beatSFX;

    void Start() {
        tempo /= 60;
    }

    void Update() {
        transform.position -= new Vector3(tempo * Time.deltaTime, 0, 0);
    }

    internal void OnPerfectTrigger() {
        SFXManager.instance.PlaySFXClip(beatSFX, transform, 0.25f);
        Debug.Log("Perfect");
        ScoreManager.instance.PerfectBeat();
        CPRMinigameManager.instance.beatTriggered++;
        Destroy(gameObject);
    }

    internal void OnGoodTrigger() {
        SFXManager.instance.PlaySFXClip(beatSFX, transform, 0.25f);
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
