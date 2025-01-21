using UnityEngine;

public class CPRStageStepManager : MonoBehaviour {
    public static CPRStageStepManager instance;
    internal Enum_CPRStageStep currentStep = Enum_CPRStageStep.StepOne;

    [Header("Attributes")]
    [SerializeField] GameObject noseHitbox;
    [SerializeField] GameObject correctCPRHitbox;
    [SerializeField] GameObject wrongCPRHitbox;
    [SerializeField] GameObject itemUsingHitbox;

    private void Awake() {
        instance = this;
    }

    private void Start() {
        OnInitiateStep(currentStep);
    }

    void OnInitiateStep(Enum_CPRStageStep step) {
        switch (step) {
            case Enum_CPRStageStep.StepOne:
                Debug.Log("Check for breathing");
                noseHitbox.SetActive(true);
                correctCPRHitbox.SetActive(false);
                wrongCPRHitbox.SetActive(false);
                itemUsingHitbox.SetActive(false);
                break;
            case Enum_CPRStageStep.StepTwo:
                Debug.Log("Call for ambulance");
                noseHitbox.SetActive(false);
                correctCPRHitbox.SetActive(false);
                wrongCPRHitbox.SetActive(false);
                itemUsingHitbox.SetActive(true);
                break;
            case Enum_CPRStageStep.StepThree:
                Debug.Log("Start CPR");
                noseHitbox.SetActive(false);
                correctCPRHitbox.SetActive(true);
                wrongCPRHitbox.SetActive(true);
                itemUsingHitbox.SetActive(false);
                break;
            case Enum_CPRStageStep.StepFour:
                Debug.Log("Help Breathing");
                noseHitbox.SetActive(true);
                correctCPRHitbox.SetActive(false);
                wrongCPRHitbox.SetActive(false);
                itemUsingHitbox.SetActive(false);
                break;
            case Enum_CPRStageStep.End:
                Debug.Log("End");
                noseHitbox.SetActive(false);
                correctCPRHitbox.SetActive(false);
                wrongCPRHitbox.SetActive(false);
                itemUsingHitbox.SetActive(false);
                break;
            default:
                Debug.Log("Invalid Step");
                break;
        }
    }

    void OnStepCompleted() {
        ++currentStep;
        Debug.Log($"Step Updated!\nCurrent Step: {currentStep}");
        OnInitiateStep(currentStep);
    }
}
