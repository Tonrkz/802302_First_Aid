using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class ScratchStageStepManager : MonoBehaviour
{
    public static ScratchStageStepManager instance;
    internal Enum_ScratchStageStep thisScratchStageStep = Enum_ScratchStageStep.StepOne;

    public UnityEvent OnUsedItem;
    public UnityEvent OnFinishedUsedItem;

    void Awake()
    {
        instance = this; 
    }

    public void DisplayStepText() {
        switch (thisScratchStageStep) {
            case Enum_ScratchStageStep.StepOne:
                UserInterfaceManager.instance.UpdateText(UserInterfaceManager.instance.updateScoreText, $"+{ScoreManager.instance.deltaScore} ล้างแผลด้วยสบู่");
                break;
            case Enum_ScratchStageStep.StepTwo:
                UserInterfaceManager.instance.UpdateText(UserInterfaceManager.instance.updateScoreText, $"+{ScoreManager.instance.deltaScore} ล้างน้ำสะอาด");
                break;
            case Enum_ScratchStageStep.StepThree:
                UserInterfaceManager.instance.UpdateText(UserInterfaceManager.instance.updateScoreText, $"+{ScoreManager.instance.deltaScore} ซับด้วยผ้าให้แห้ง");
                break;
            case Enum_ScratchStageStep.StepFour:
                UserInterfaceManager.instance.UpdateText(UserInterfaceManager.instance.updateScoreText, $"+{ScoreManager.instance.deltaScore} ใช้แอลกอฮอลเช็ดรอบ ๆ แผล");
                break;
            case Enum_ScratchStageStep.StepFive:
                UserInterfaceManager.instance.UpdateText(UserInterfaceManager.instance.updateScoreText, $"+{ScoreManager.instance.deltaScore} ใช้เบตาดีนกำจัดเชื้อโรคบริเวณแผล");
                break;
            default:
                UserInterfaceManager.instance.UpdateText(UserInterfaceManager.instance.updateScoreText, $"+{ScoreManager.instance.deltaScore}");
                break;
        }
    }

    public void UpdateState()
    {
        thisScratchStageStep++;
        Debug.Log($"Step Update!\n Current Step:{thisScratchStageStep}");
        if (thisScratchStageStep == Enum_ScratchStageStep.EndStage)
        {
            ScoreManager.instance.StageCleared();
        }
    }
}
