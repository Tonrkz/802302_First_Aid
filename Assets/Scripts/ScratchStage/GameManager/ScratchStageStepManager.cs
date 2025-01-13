using UnityEngine;

public class ScratchStageStepManager : MonoBehaviour
{
    public static ScratchStageStepManager instance;
    internal Enum_StageStep thisScratchStageStep = Enum_StageStep.StepOne;

    void Awake()
    {
        instance = this; 
    }

    public void UpdateState()
    {
        thisScratchStageStep++;
        Debug.Log($"Step Update!\n Current Step:{thisScratchStageStep}");
    }
}
