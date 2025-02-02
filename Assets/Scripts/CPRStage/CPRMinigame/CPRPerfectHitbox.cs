using UnityEngine;

public class CPRPerfectHitbox : MonoBehaviour {
    [Header("References")]
    [SerializeField] GameObject trigger;

    [Header("Audio")]
    [SerializeField] AudioClip heartBeatSFX;

    private void OnTriggerEnter2D(Collider2D collision) {
        SFXManager.instance.PlaySFXClip(heartBeatSFX, transform, 1f);
    }

    private void OnTriggerStay2D(Collider2D collision) {
        if (collision.GetComponent<CPR_Beat>() != null && trigger.GetComponent<CPRTrigger>().isTriggered) {
            collision.GetComponent<CPR_Beat>().OnPerfectTrigger();
        }
    }
}
