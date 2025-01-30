using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class CPRStageStepManager : MonoBehaviour {
    public static CPRStageStepManager instance;
    internal Enum_CPRStageStep currentStep = Enum_CPRStageStep.StepOne;

    [Header("Attributes")]
    [SerializeField] GameObject noseHitbox;
    [SerializeField] GameObject correctCPRHitbox;
    [SerializeField] GameObject itemUsingHitbox;
    [SerializeField] List<GameObject> itemList = new List<GameObject>();

    void Awake() {
        instance = this;
    }

    void Start() {
        OnInitiateStep(currentStep);
    }

    void OnInitiateStep(Enum_CPRStageStep step) {
        switch (step) {
            case Enum_CPRStageStep.StepOne:
                Debug.Log("Check for breathing");
                noseHitbox.SetActive(true);
                correctCPRHitbox.SetActive(false);
                itemUsingHitbox.SetActive(true);
                foreach (GameObject item in itemList) {
                    item.SetActive(true);
                }
                break;
            case Enum_CPRStageStep.StepTwo:
                Debug.Log("Call for ambulance");
                noseHitbox.SetActive(false);
                correctCPRHitbox.SetActive(false);
                itemUsingHitbox.SetActive(true);
                break;
            case Enum_CPRStageStep.StepThree:
                Debug.Log("Start CPR");
                noseHitbox.SetActive(false);
                correctCPRHitbox.SetActive(true);
                itemUsingHitbox.SetActive(true);
                foreach (GameObject item in itemList) {
                    item.SetActive(false);
                }
                CPRMinigameManager.instance.InitiateCPRMinigame();
                break;
            case Enum_CPRStageStep.StepFour:
                Debug.Log("Help Breathing");
                noseHitbox.SetActive(true);
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
        if (currentStep != Enum_CPRStageStep.StepThree) {
            ScoreManager.instance.AddScore();
        }
        switch (currentStep) {
            case Enum_CPRStageStep.StepOne:
                UserInterfaceManager.instance.UpdateText(UserInterfaceManager.instance.updateScoreText, $"+{ScoreManager.instance.deltaScore} ตรวจสอบลมหายใจ");
                break;
            case Enum_CPRStageStep.StepTwo:
                UserInterfaceManager.instance.UpdateText(UserInterfaceManager.instance.updateScoreText, $"+{ScoreManager.instance.deltaScore} โทรเรียกรถพยาบาล");
                break;
            case Enum_CPRStageStep.StepThree:
                CPRMinigameManager.instance.EndCPRMinigame();
                break;
            case Enum_CPRStageStep.StepFour:
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
