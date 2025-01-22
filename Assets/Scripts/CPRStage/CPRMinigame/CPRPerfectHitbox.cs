using UnityEngine;

public class CPRPerfectHitbox : MonoBehaviour {
    [SerializeField] GameObject trigger;

    private void OnTriggerStay2D(Collider2D collision) {
        Debug.Log("Collision detected");
        if (collision.GetComponent<CPR_Beat>() != null && trigger.GetComponent<CPRTrigger>().isTriggered) {
            collision.GetComponent<CPR_Beat>().OnPerfectTrigger();
        }
    }
}
