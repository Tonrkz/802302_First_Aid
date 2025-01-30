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
                UserInterfaceManager.instance.UpdateText(UserInterfaceManager.instance.updateScoreText, $"+{ScoreManager.instance.deltaScore} ล้างแผลด้วยสบู่");
                break;
            case Enum_ScratchStageStep.StepTwo:
                UserInterfaceManager.instance.UpdateText(UserInterfaceManager.instance.updateScoreText, $"+{ScoreManager.instance.deltaScore} ล้างแผลด้วยน้ำสะอาด");
                break;
            case Enum_ScratchStageStep.StepThree:
                UserInterfaceManager.instance.UpdateText(UserInterfaceManager.instance.updateScoreText, $"+{ScoreManager.instance.deltaScore} ซับด้วยผ้าให้แห้ง");
                break;
            case Enum_ScratchStageStep.StepFour:
                UserInterfaceManager.instance.UpdateText(UserInterfaceManager.instance.updateScoreText, $"+{ScoreManager.instance.deltaScore} แอลกอฮอล์เช็ดแผล");
                break;
            case Enum_ScratchStageStep.StepFive:
                UserInterfaceManager.instance.UpdateText(UserInterfaceManager.instance.updateScoreText, $"+{ScoreManager.instance.deltaScore} ทาเบตาดีน");
                break;
            default:
                UserInterfaceManager.instance.UpdateText(UserInterfaceManager.instance.updateScoreText, $"+{ScoreManager.instance.deltaScore}");
                break;
        }
        if (thisScratchStageStep == Enum_ScratchStageStep.EndStage)
        {
            ScoreManager.instance.StageCleared();
        }
    }
}
