using UnityEngine;

public class CPRMissHitbox : MonoBehaviour {
    private void OnTriggerStay2D(Collider2D collision) {
        if (collision.GetComponent<CPR_Beat>() != null) {
            collision.GetComponent<CPR_Beat>().OnMissedTrigger();
        }
    }
}
