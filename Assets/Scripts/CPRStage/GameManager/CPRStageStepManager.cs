using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class CPRStageStepManager : MonoBehaviour {
    public static CPRStageStepManager instance;
    internal Enum_CPRStageStep currentStep = Enum_CPRStageStep.CheckForBreath;

    [Header("References")]
    [SerializeField] GameObject stageBackground;

    [Header("Attributes")]
    [SerializeField] GameObject noseHitbox;
    [SerializeField] GameObject correctCPRHitbox;
    [SerializeField] GameObject itemUsingHitbox;
    [SerializeField] List<GameObject> itemList = new List<GameObject>();

    [Header("Audio")]
    [SerializeField] AudioClip correctItemSFX;

    void Awake() {
        instance = this;
    }

    void Start() {
        OnInitiateStep(currentStep);
    }

    void OnInitiateStep(Enum_CPRStageStep step) {
        switch (step) {
            case Enum_CPRStageStep.CheckForBreath:
                Debug.Log("Check for breathing");
                noseHitbox.SetActive(true);
                correctCPRHitbox.SetActive(false);
                itemUsingHitbox.SetActive(true);
                foreach (GameObject item in itemList) {
                    item.SetActive(true);
                }
                break;
            case Enum_CPRStageStep.CallAmbulance:
                Debug.Log("Call for ambulance");
                noseHitbox.SetActive(false);
                correctCPRHitbox.SetActive(false);
                itemUsingHitbox.SetActive(true);
                break;
            case Enum_CPRStageStep.StartCPR:
                Debug.Log("Start CPR");
                UserInterfaceManager.instance.FadeTint(stageBackground, new Color(0.5f, 0.5f, 0.5f, 1f));
                noseHitbox.SetActive(false);
                correctCPRHitbox.SetActive(true);
                itemUsingHitbox.SetActive(false);
                CPRMinigameManager.instance.InitiateCPRMinigame();
                foreach (GameObject item in itemList) {
                    item.SetActive(false);
                }
                break;
            case Enum_CPRStageStep.LungResuscitation:
                Debug.Log("Help Breathing");
                UserInterfaceManager.instance.FadeTint(stageBackground, Color.white);
                noseHitbox.SetActive(true);
                noseHitbox.GetComponent<Collider2D>().enabled = true;
                correctCPRHitbox.SetActive(false);
                itemUsingHitbox.SetActive(true);
                foreach (GameObject item in itemList) {
                    item.SetActive(true);
                }
                break;
            case Enum_CPRStageStep.End:
                Debug.Log("End");
                ScoreManager.instance.StageCleared();
                break;
            default:
                Debug.Log("Invalid Step");
                break;
        }
    }

    internal void OnStepCompleted() {
        SFXManager.instance.PlaySFXClip(correctItemSFX, transform, 1f);
        if (currentStep != Enum_CPRStageStep.StartCPR) {
            ScoreManager.instance.AddScore();
        }
        switch (currentStep) {
            case Enum_CPRStageStep.CheckForBreath:
                UserInterfaceManager.instance.UpdateText(UserInterfaceManager.instance.updateScoreText, $"+{ScoreManager.instance.deltaScore} ตรวจสอบลมหายใจ");
                break;
            case Enum_CPRStageStep.CallAmbulance:
                UserInterfaceManager.instance.UpdateText(UserInterfaceManager.instance.updateScoreText, $"+{ScoreManager.instance.deltaScore} โทรเรียกรถพยาบาล");
                break;
            case Enum_CPRStageStep.StartCPR:
                CPRMinigameManager.instance.EndCPRMinigame();
                UserInterfaceManager.instance.UpdateText(UserInterfaceManager.instance.updateScoreText, $"กดหน้าอกปั๊มหัวใจ");
                break;
            case Enum_CPRStageStep.LungResuscitation:
                UserInterfaceManager.instance.UpdateText(UserInterfaceManager.instance.updateScoreText, $"+{ScoreManager.instance.deltaScore} ผายปอด");
                break;
            case Enum_CPRStageStep.End:
                break;
            default:
                break;
        }
        ++currentStep;
        Debug.Log($"Step Updated!\nCurrent Step: {currentStep}");
        OnInitiateStep(currentStep);
    }
}
