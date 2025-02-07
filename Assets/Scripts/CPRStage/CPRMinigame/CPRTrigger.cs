using UnityEngine;
using UnityEngine.EventSystems;

public class CPRTrigger : MonoBehaviour, IPointerDownHandler, IPointerUpHandler {
    [Header("References")]
    [SerializeField] GameObject firstHandCPR;

    [Header("Debug")]
    internal bool isTriggered = false;

    public void OnPointerDown(PointerEventData eventData) {
        Debug.Log("Triggered");
        GetComponentInChildren<SpriteRenderer>().color = new Color(1, 1, 1, 0.75f);
        GetComponentInChildren<SpriteRenderer>().transform.localScale = new Vector3(1.4f, 1.4f, 1.4f);
        isTriggered = true;
    }

    public void OnPointerUp(PointerEventData eventData) {
        Debug.Log("Untriggered");
        GetComponentInChildren<SpriteRenderer>().color = new Color(1, 1, 1, 1);
        GetComponentInChildren<SpriteRenderer>().transform.localScale = new Vector3(1.65f, 1.65f, 1.65f);
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
