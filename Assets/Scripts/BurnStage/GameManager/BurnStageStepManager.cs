using UnityEngine;

public class BurnStageStepManager : MonoBehaviour {
    public static BurnStageStepManager instance;
    Enum_BurnStageStep currentStep = Enum_BurnStageStep.StepOne;

    void Awake() {
        instance = this;
    }
}
