using System.Collections;
using UnityEditorInternal.Profiling.Memory.Experimental;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class DragableItem : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler, IEndDragHandler, IPointerEnterHandler, IPointerExitHandler {
    [Header("References")]
    Rigidbody2D rb;

    [Header("Attributes")]
    public bool isDragging = false;
    Vector2 originPosition;
    float lerpSpeed = 0.1f;

    void Awake() {
        GameObject mainCam = GameObject.Find("Main Camera");
        if (mainCam.GetComponent<Physics2DRaycaster>() == null) {
            AddPhysics2DRaycaster(mainCam);
        }
        if (FindAnyObjectByType<EventSystem>() == null) {
            CreateEventSystems();
        }
        if (GetComponent<Rigidbody2D>() == null) {
            rb = gameObject.AddComponent<Rigidbody2D>();
            rb.gravityScale = 0;
            rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        }
        originPosition = transform.position;
    }

    void FixedUpdate() {
        if (isDragging) {
            MoveObject();
        }
        else {
            ResetPosition();
        }
    }

    void ResetPosition() {
        transform.position = Vector2.Lerp(transform.position, originPosition, lerpSpeed);
        if (Vector2.Distance(transform.position, originPosition) < 0.1f) {
            GetComponent<Collider2D>().enabled = true;
        }
    }

    IEnumerator ResetPositionCoroutine() {
        yield return new WaitForFixedUpdate();
        GetComponent<Collider2D>().enabled = false;
    }

    void AddPhysics2DRaycaster(GameObject cam) {
        cam.AddComponent<Physics2DRaycaster>();
        Debug.Log("Physics2DRaycaster added");
    }

    void CreateEventSystems() {
        var eventSystem = new GameObject("EventSystem", typeof(EventSystem), typeof(StandaloneInputModule));
        Debug.Log("EventSystem created");
    }

    void MoveObject() {
        Vector2 mousePos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        rb.MovePosition(Vector2.Lerp(transform.position, Camera.main.ScreenToWorldPoint(mousePos), lerpSpeed));
    }

    public void OnPointerDown(PointerEventData eventData) {
        Debug.Log($"Clicked: {eventData.pointerCurrentRaycast.gameObject.name}");
    }

    public void OnPointerUp(PointerEventData eventData) {
        Debug.Log("Pointer Up");
    }

    public void OnDrag(PointerEventData eventData) {
        isDragging = true;
        Debug.Log("Dragging");
    }

    public void OnEndDrag(PointerEventData eventData) {
        isDragging = false;
        StartCoroutine(ResetPositionCoroutine());
        Debug.Log("End Drag");
    }
    public void OnPointerEnter(PointerEventData eventData) {
        Debug.Log("Pointer Enter");
    }

    public void OnPointerExit(PointerEventData eventData) {
        Debug.Log("Pointer Exit");
    }
}
