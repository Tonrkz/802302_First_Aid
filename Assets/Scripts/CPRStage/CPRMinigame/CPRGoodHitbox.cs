using UnityEngine;

public class CPRGoodHitbox : MonoBehaviour {
    [SerializeField] GameObject trigger;

    private void OnTriggerStay2D(Collider2D collision) {
        if (collision.GetComponent<CPR_Beat>() != null && trigger.GetComponent<CPRTrigger>().isTriggered) {
            collision.GetComponent<CPR_Beat>().OnGoodTrigger();
        }
    }
}
