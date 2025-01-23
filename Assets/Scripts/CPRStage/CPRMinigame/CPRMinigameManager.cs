using System;
using UnityEngine;

public class CPRMinigameManager : MonoBehaviour {
    public static CPRMinigameManager instance;

    [SerializeField] GameObject CPRUserInterface;
    [SerializeField] GameObject beatPrefab;
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
            CPRStageStepManager.instance.OnStepCompleted();
        }
    }

    internal void MissedBeat() {
        beatMissed++;
        if (beatMissed >= 7) {
            EndCPRMinigame(); //Game Over
        }
    }

    void SpawnBeat() {
        GameObject beat = Instantiate(beatPrefab, CPRUserInterface.transform, false);
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
