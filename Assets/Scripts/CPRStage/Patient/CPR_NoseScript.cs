using UnityEngine;
using UnityEngine.EventSystems;

public class CPR_NoseScript : MonoBehaviour, IPointerDownHandler {

    public void OnPointerDown(PointerEventData eventData) {
        switch (CPRStageStepManager.instance.currentStep) {
            case Enum_CPRStageStep.StepOne:
                CPRStageStepManager.instance.OnStepCompleted();
                break;
            case Enum_CPRStageStep.StepTwo:
                break;
            case Enum_CPRStageStep.StepThree:
                break;
            case Enum_CPRStageStep.StepFour:
                CPRStageStepManager.instance.OnStepCompleted();
                break;
            case Enum_CPRStageStep.End:
                break;
            default:
                break;
        }
    }
}
