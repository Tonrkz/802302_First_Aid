using UnityEngine;

public class CleanCloth : MonoBehaviour, IUseable {
    [Header("References")]
    [SerializeField] Animator animatorController;

    void Start() {
        animatorController = GetComponent<Animator>();
    }

    public void UseItem() {
        Debug.Log("Cloth Used");
        animatorController.SetBool("isUsed", true);
    }

    public void AnimNotifyDestroyGameObject() {
        Destroy(gameObject);
    }
}
