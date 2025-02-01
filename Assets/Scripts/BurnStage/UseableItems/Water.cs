using UnityEngine;

public class Water : MonoBehaviour, IUseable {
    [Header("References")]
    [SerializeField] Animator animatorController;

    void Start() {
        animatorController = GetComponent<Animator>();
    }

    public void UseItem() {
        Debug.Log("Water Used");
        animatorController.SetBool("isUsed", true);
    }

    public void AnimNotifyDestroyGameObject() {
        Destroy(gameObject);
    }
}
