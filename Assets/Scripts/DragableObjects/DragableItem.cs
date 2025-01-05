using UnityEditorInternal.Profiling.Memory.Experimental;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragableItem : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler, IEndDragHandler {

    void Start() {
        GameObject mainCam = GameObject.Find("Main Camera");
        if (mainCam.GetComponent<Physics2DRaycaster>() == null) {
            AddPhysics2DRaycaster(mainCam);
        }
        if (FindAnyObjectByType<EventSystem>() == null) {
            CreateEventSystems();
        }
    }

    void AddPhysics2DRaycaster(GameObject cam) {
        cam.AddComponent<Physics2DRaycaster>();
        Debug.Log("Physics2DRaycaster added");
    }

    void CreateEventSystems() {
        var eventSystem = new GameObject("EventSystem", typeof(EventSystem), typeof(StandaloneInputModule));
        Debug.Log("EventSystem created");
    }

    public void OnPointerDown(PointerEventData eventData) {
        Debug.Log($"Clicked: {eventData.pointerCurrentRaycast.gameObject.name}");
    }

    public void OnPointerUp(PointerEventData eventData) {
        Debug.Log("Pointer Up");
    }

    public void OnDrag(PointerEventData eventData) {
        Debug.Log("Dragging");
    }

    public void OnEndDrag(PointerEventData eventData) {
        Debug.Log("End Drag");
    }
}
