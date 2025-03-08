using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class BurnStageStepManager : MonoBehaviour {
    public static BurnStageStepManager instance;
    internal Enum_BurnStageStep currentStep = Enum_BurnStageStep.StepOne;

    public UnityEvent OnUsedItem;
    public UnityEvent OnFinishedUsedItem;

    void Awake() {
        instance = this;
    }

    public void DisplayStepText() {
        switch (currentStep) {
            case Enum_BurnStageStep.StepOne:
                UserInterfaceManager.instance.UpdateText(UserInterfaceManager.instance.updateScoreText, $"+{ScoreManager.instance.deltaScore} ล้างแผลด้วยน้ำสะอาด");
                break;
            case Enum_BurnStageStep.StepTwo:
                UserInterfaceManager.instance.UpdateText(UserInterfaceManager.instance.updateScoreText, $"+{ScoreManager.instance.deltaScore} ซับแผลให้แห้ง");
                break;
            case Enum_BurnStageStep.StepThree:
                UserInterfaceManager.instance.UpdateText(UserInterfaceManager.instance.updateScoreText, $"+{ScoreManager.instance.deltaScore} ปิดแผลด้วยผ้าก็อซ");
                break;
            default:
                UserInterfaceManager.instance.UpdateText(UserInterfaceManager.instance.updateScoreText, $"+{ScoreManager.instance.deltaScore}");
                break;
        }
    }

    public void UpdateStep() {
        ++currentStep;
        Debug.Log($"Step Updated!\nCurrent Step: {currentStep}");
        if (currentStep == Enum_BurnStageStep.EndStage) {
            ScoreManager.instance.StageCleared();
        }
    }
}
