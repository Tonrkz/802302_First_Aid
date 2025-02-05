using UnityEngine;
using UnityEngine.EventSystems;

public class CPRTrigger : MonoBehaviour, IPointerDownHandler, IPointerUpHandler {
    [Header("References")]
    [SerializeField] GameObject firstHandCPR;

    [Header("Debug")]
    internal bool isTriggered = false;

    public void OnPointerDown(PointerEventData eventData) {
        Debug.Log("Triggered");
        isTriggered = true;
    }

    public void OnPointerUp(PointerEventData eventData) {
        Debug.Log("Untriggered");
        isTriggered = false;
    }

    private void OnTriggerStay2D(Collider2D other) {
        switch (CPRStageStepManager.instance.currentStep) {
            case Enum_CPRStageStep.FirstHandCPR:
                if (other.GetComponent<DragableItem>() != null) {
                    if (!other.GetComponent<DragableItem>().isDragging && other.gameObject == firstHandCPR) {
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
