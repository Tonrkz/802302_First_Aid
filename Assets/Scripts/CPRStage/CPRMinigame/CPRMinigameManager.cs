using System;
using UnityEngine;

public class CPRMinigameManager : MonoBehaviour {
    public static CPRMinigameManager instance;

    [SerializeField] GameObject CPRUserInterface;
    [SerializeField] GameObject beatPrefab;
    [SerializeField] GameObject spawnPoint;
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
        if(Input.GetKeyDown(KeyCode.Space)) {
            CPRStageCharacter.instance.OnCorrectItemForEachStep();
        }
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
        CPRUserInterface.SetActive(true);
        hasStarted = true;
    }

    internal void EndCPRMinigame() {
        CPRUserInterface.SetActive(false);
        hasStarted = false;
    }
}
