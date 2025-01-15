using UnityEngine;

public class ScratchStageStepManager : MonoBehaviour
{
    public static ScratchStageStepManager instance;
    internal Enum_ScratchStageStep thisScratchStageStep = Enum_ScratchStageStep.StepOne;

    void Awake()
    {
        instance = this; 
    }

    public void UpdateState()
    {
        thisScratchStageStep++;
        Debug.Log($"Step Update!\n Current Step:{thisScratchStageStep}");
        switch (thisScratchStageStep - 1)
        {
            case Enum_ScratchStageStep.StepOne:
                UserInterfaceManager.instance.UpdateText(UserInterfaceManager.instance.updateScoreText, $"+{ScoreManager.instance.deltaScore} Clean wound with soap");
                break;
            case Enum_ScratchStageStep.StepTwo:
                UserInterfaceManager.instance.UpdateText(UserInterfaceManager.instance.updateScoreText, $"+{ScoreManager.instance.deltaScore} Clean wound with clean-water");
                break;
            case Enum_ScratchStageStep.StepThree:
                UserInterfaceManager.instance.UpdateText(UserInterfaceManager.instance.updateScoreText, $"+{ScoreManager.instance.deltaScore} Dry wound with Cloth");
                break;
            case Enum_ScratchStageStep.StepFour:
                UserInterfaceManager.instance.UpdateText(UserInterfaceManager.instance.updateScoreText, $"+{ScoreManager.instance.deltaScore} Clean wound with Alchohol");
                break;
            case Enum_ScratchStageStep.StepFive:
                UserInterfaceManager.instance.UpdateText(UserInterfaceManager.instance.updateScoreText, $"+{ScoreManager.instance.deltaScore} Clean wound with Betadine");
                break;
            default:
                UserInterfaceManager.instance.UpdateText(UserInterfaceManager.instance.updateScoreText, $"+{ScoreManager.instance.deltaScore}");
                break;
        }
    }
}
