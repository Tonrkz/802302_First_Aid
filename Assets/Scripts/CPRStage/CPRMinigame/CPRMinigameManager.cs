using System;
using UnityEngine;
using DG.Tweening;

public class CPRMinigameManager : MonoBehaviour {
    public static CPRMinigameManager instance;
    [Header("References")]
    [SerializeField] GameObject CPRUserInterface;
    [SerializeField] GameObject beatPrefab;
    [SerializeField] GameObject spawnPoint;
    [SerializeField] public GameObject hitboxCPR;

    [Header("Audios")]
    [SerializeField] AudioClip heartBeatSFX;
    AudioSource hearBeat;

    [Header("Debug")]
    Byte beatCount = 30;
    Byte beatCounter = 0;
    Byte beatMissed = 0;
    internal Byte beatTriggered = 0;
    float tempo = 120;
    float timeTreashold = 0;
    float beatTimer = 0;
    bool hasStarted = false;

    void Awake() {
        instance = this;
        timeTreashold = 60 / tempo;
    }

    void Start() {
        CPRUserInterface.SetActive(false);
    }

    void Update() {
        if (beatCounter < beatCount && hasStarted) {
            beatTimer += Time.deltaTime;
            if (beatTimer >= timeTreashold) {
                beatTimer -= timeTreashold;
                SpawnBeat();
            }
        } else if (beatMissed + beatTriggered == beatCount && hasStarted) {
            EndCPRMinigame();
            CPRStageCharacter.instance.OnCorrectItemForEachStep();
        }
    }

    internal void MissedBeat() {
        beatMissed++;
        if (beatMissed >= 7) {
            EndCPRMinigame();
            ScoreManager.instance.GameOver(); //Game Over
        }
    }

    void SpawnBeat() {
        GameObject beat = Instantiate(beatPrefab, spawnPoint.transform.position, Quaternion.identity);
        beat.transform.SetParent(spawnPoint.transform);
        Debug.Log("Beat Spawned");
        beatCounter++;
    }

    internal void InitiateCPRMinigame() {
        hitboxCPR.GetComponentInChildren<SpriteRenderer>().color = new Color(1, 1, 1, 1);
        CPRUserInterface.SetActive(true);
        hasStarted = true;
        hearBeat = SFXManager.instance.PlaySFXClip(heartBeatSFX, gameObject.transform, 1f, false);
        DG.Tweening.DOTweenModuleAudio.DOFade(BGMManager.instance.BGMObject, 0.05f, 0.5f);
    }

    internal void EndCPRMinigame() {
        hitboxCPR.GetComponentInChildren<SpriteRenderer>().color = new Color(1, 1, 1, 0);
        CPRUserInterface.SetActive(false);
        hasStarted = false;
        DG.Tweening.DOTweenModuleAudio.DOFade(BGMManager.instance.BGMObject, 0.125f, 0.5f);
        Destroy(hearBeat);
    }
}
