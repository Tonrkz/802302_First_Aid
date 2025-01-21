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
                break;
            case Enum_CPRStageStep.StepTwo:
                Debug.Log("Call for ambulance");
                break;
            case Enum_CPRStageStep.StepThree:
                Debug.Log("Start CPR");
                break;
            case Enum_CPRStageStep.StepFour:
                Debug.Log("Help Breathing");
                break;
            case Enum_CPRStageStep.End:
                Debug.Log("End");
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
