using UnityEngine;

public class BurnStageStepManager : MonoBehaviour {
    public static BurnStageStepManager instance;
    internal Enum_BurnStageStep currentStep = Enum_BurnStageStep.StepOne;

    public void UpdateStep() {
        ++currentStep;
        Debug.Log($"Step Updated!\nCurrent Step: {currentStep}");
    }

    void Awake() {
        instance = this;
    }
}
