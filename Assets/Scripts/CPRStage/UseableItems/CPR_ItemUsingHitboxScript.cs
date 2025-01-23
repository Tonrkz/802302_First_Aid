using UnityEngine;

public class CPR_ItemUsingHitboxScript : MonoBehaviour {
    [SerializeField] GameObject phone;

    private void OnTriggerStay2D(Collider2D other) {
        switch (CPRStageStepManager.instance.currentStep) {
            case Enum_CPRStageStep.StepOne: // Check for breathing
                if (other.GetComponent<DragableItem>() != null) {
                    if (!other.GetComponent<DragableItem>().isDragging) {
                        ScoreManager.instance.SubtractScore();
                    }
                }
                break;
            case Enum_CPRStageStep.StepTwo: // Call for ambulance
                if (other.GetComponent<DragableItem>() != null) {
                    if (!other.GetComponent<DragableItem>().isDragging && other.gameObject == phone) {
                        UserInterfaceManager.instance.UpdateText(UserInterfaceManager.instance.updateScoreText, $"+{ScoreManager.instance.deltaScore} Call for ambulance.");
                        other.gameObject.GetComponent<IUseable>().UseItem();
                        CPRStageStepManager.instance.OnStepCompleted();
                    }
                    else if (!other.GetComponent<DragableItem>().isDragging) {
                        ScoreManager.instance.SubtractScore();
                    }
                }
                break;
            case Enum_CPRStageStep.StepThree: // Start CPR
                break;
            case Enum_CPRStageStep.StepFour:// Help Breathing
                if (other.GetComponent<DragableItem>() != null) {
                    if (!other.GetComponent<DragableItem>().isDragging) {
                        ScoreManager.instance.SubtractScore();
                    }
                }
                break;
            case Enum_CPRStageStep.End:
                break;
            default:
                break;
        }
    }
}
