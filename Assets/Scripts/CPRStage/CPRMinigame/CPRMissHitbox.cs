using UnityEngine;

public class CPRMissHitbox : MonoBehaviour {
    [Header("Audio")]
    [SerializeField] AudioClip missSFX;

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.GetComponent<CPR_Beat>() != null) {
            SFXManager.instance.PlaySFXClip(missSFX, transform, 1f);
            collision.GetComponent<CPR_Beat>().OnMissedTrigger();
        }
    }
}
