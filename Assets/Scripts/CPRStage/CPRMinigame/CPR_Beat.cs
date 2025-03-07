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
        CPRMinigameManager.instance.CPRheart.SetTrigger("Hit");
        Destroy(gameObject);
    }

    internal void OnGoodTrigger() {
        SFXManager.instance.PlaySFXClip(beatSFX, transform, 0.25f);
        Debug.Log("Good");
        ScoreManager.instance.GoodBeat();
        CPRMinigameManager.instance.beatTriggered++;
        CPRMinigameManager.instance.CPRheart.SetTrigger("Hit");
        Destroy(gameObject);
    }

    internal void OnMissedTrigger() {
        Debug.Log("Missed");
        CPRMinigameManager.instance.MissedBeat();
        ScoreManager.instance.MissedBeat();
        if (ScoreManager.instance.score > 0 && CPRMinigameManager.instance.beatMissed < 7) {
            StartCoroutine(ScoreManager.instance.ShowWrongStepHUD("Anim_WrongStepHUD_Short"));
        }
        Destroy(gameObject);
    }
}
