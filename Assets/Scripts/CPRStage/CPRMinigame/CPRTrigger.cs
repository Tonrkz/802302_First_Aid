using UnityEngine;
using UnityEngine.EventSystems;

public class CPRTrigger : MonoBehaviour, IPointerDownHandler, IPointerUpHandler {
    internal bool isTriggered = false;

    public void OnPointerDown(PointerEventData eventData) {
        Debug.Log("Triggered");
        isTriggered = true;
    }

    public void OnPointerUp(PointerEventData eventData) {
        Debug.Log("Untriggered");
        isTriggered = false;
    }
}
