using UnityEngine;

public class ScratchStageStepManager : MonoBehaviour
{
    public static ScratchStageStepManager instance;
    Enum_StageStep thisScratchStage = Enum_StageStep.StepOne;

    void Awake()
    {
        instance = this; 
    }
}
