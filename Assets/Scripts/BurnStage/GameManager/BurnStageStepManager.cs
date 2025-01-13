using UnityEngine;

public class BurnStageStepManager : MonoBehaviour {
    public static BurnStageStepManager instance;
    internal Enum_BurnStageStep currentStep = Enum_BurnStageStep.StepOne;

    public void UpdateStep() {
        ++currentStep;
        Debug.Log($"Step Updated!\nCurrent Step: {currentStep}");
        switch (currentStep - 1) {
            case Enum_BurnStageStep.StepOne:
                UserInterfaceManager.instance.UpdateText(UserInterfaceManager.instance.updateScoreText, $"+{ScoreManager.instance.deltaScore} Lang Plae Duae Nam Sa-ard");
                break;
            case Enum_BurnStageStep.StepTwo:
                UserInterfaceManager.instance.UpdateText(UserInterfaceManager.instance.updateScoreText, $"+{ScoreManager.instance.deltaScore} Sub Hai Hang");
                break;
            case Enum_BurnStageStep.StepThree:
                UserInterfaceManager.instance.UpdateText(UserInterfaceManager.instance.updateScoreText, $"+{ScoreManager.instance.deltaScore} Pid Pha Gauze");
                break;
            default:
                UserInterfaceManager.instance.UpdateText(UserInterfaceManager.instance.updateScoreText, $"+{ScoreManager.instance.deltaScore}");
                break;
        }
    }

    void Awake() {
        instance = this;
    }
}
