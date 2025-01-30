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
                UserInterfaceManager.instance.UpdateText(UserInterfaceManager.instance.updateScoreText, $"+{ScoreManager.instance.deltaScore} ��ҧ�Ŵ���ʺ��");
                break;
            case Enum_ScratchStageStep.StepTwo:
                UserInterfaceManager.instance.UpdateText(UserInterfaceManager.instance.updateScoreText, $"+{ScoreManager.instance.deltaScore} ��ҧ�Ŵ��¹�����Ҵ");
                break;
            case Enum_ScratchStageStep.StepThree:
                UserInterfaceManager.instance.UpdateText(UserInterfaceManager.instance.updateScoreText, $"+{ScoreManager.instance.deltaScore} �Ѻ���¼��������");
                break;
            case Enum_ScratchStageStep.StepFour:
                UserInterfaceManager.instance.UpdateText(UserInterfaceManager.instance.updateScoreText, $"+{ScoreManager.instance.deltaScore} ��š���������");
                break;
            case Enum_ScratchStageStep.StepFive:
                UserInterfaceManager.instance.UpdateText(UserInterfaceManager.instance.updateScoreText, $"+{ScoreManager.instance.deltaScore} ��ີҴչ");
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
