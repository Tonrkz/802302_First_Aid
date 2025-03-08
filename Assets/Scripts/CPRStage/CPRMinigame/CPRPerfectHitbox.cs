using UnityEngine;

public class CPRPerfectHitbox : MonoBehaviour {
    [Header("References")]
    [SerializeField] GameObject trigger;

    private void OnTriggerStay2D(Collider2D collision) {
        if (collision.GetComponent<CPR_Beat>() != null && trigger.GetComponent<CPRTrigger>().isTriggered) {
            collision.GetComponent<CPR_Beat>().OnPerfectTrigger();
        }
    }
}
