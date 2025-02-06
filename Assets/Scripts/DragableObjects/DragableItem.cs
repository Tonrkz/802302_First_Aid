using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragableItem : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler, IEndDragHandler, IPointerEnterHandler, IPointerExitHandler {
    [Header("References")]
    Rigidbody2D rb;
    Canvas tooltipCanvas;

    [Header("Attributes")]
    public bool canDrag = true;
    public bool isDragging = false;
    public bool isPlayingAnimation = false;
    public Vector2 originPosition;
    float lerpSpeed = 0.15f;

    [Header("Audio")]
    [SerializeField] AudioClip clickSound;

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

    void Start() {
        tooltipCanvas = gameObject.GetComponentInChildren<Canvas>();
        if (tooltipCanvas != null) {
            tooltipCanvas.gameObject.SetActive(false);
        }
    }

    void FixedUpdate() {
        if (isDragging && !isPlayingAnimation) {
            MoveObject();
        }
        else if (!isPlayingAnimation){
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
        SFXManager.instance.PlaySFXClip(clickSound, transform.transform, 0.5f);
    }

    public void OnPointerUp(PointerEventData eventData) {
        Debug.Log("Pointer Up");
    }

    public void OnDrag(PointerEventData eventData) {
        if (!canDrag) {
            return;
        }
        isDragging = true;
        if (tooltipCanvas != null) {
            tooltipCanvas.gameObject.SetActive(false);
        }
    }

    public void OnEndDrag(PointerEventData eventData) {
        if (!canDrag) {
            return;
        }
        isDragging = false;
        StartCoroutine(ResetPositionCoroutine());
        Debug.Log("End Drag");
    }
    public void OnPointerEnter(PointerEventData eventData) {
        Debug.Log("Pointer Enter");
        if (tooltipCanvas != null && !isDragging && canDrag) {
            tooltipCanvas.gameObject.SetActive(true);
        }
    }

    public void OnPointerExit(PointerEventData eventData) {
        Debug.Log("Pointer Exit");
        if (tooltipCanvas != null) {
            tooltipCanvas.gameObject.SetActive(false);
        }
    }
}
