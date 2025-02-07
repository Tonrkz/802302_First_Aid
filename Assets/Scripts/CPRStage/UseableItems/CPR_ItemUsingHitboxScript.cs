using UnityEngine;

public class CPR_ItemUsingHitboxScript : MonoBehaviour {
    [Header("References")]
    [SerializeField] GameObject phone;

    private void OnTriggerStay2D(Collider2D other) {
        switch (CPRStageStepManager.instance.currentStep) {
            case Enum_CPRStageStep.CallAmbulance: // Call for ambulance
                if (other.GetComponent<DragableItem>() != null) {
                    if (!other.GetComponent<DragableItem>().isDragging && other.gameObject == phone) {
                        other.gameObject.GetComponent<IUseable>().UseItem();
                    }
                    else if (!other.GetComponent<DragableItem>().isDragging) {
                        CPRStageStepManager.instance.OnStepWrong();
                    }
                }
                break;
            default:
                if (other.GetComponent<DragableItem>() != null) {
                    if (!other.GetComponent<DragableItem>().isDragging) {
                        CPRStageStepManager.instance.OnStepWrong();
                    }
                }
                break;
        }
    }
}
