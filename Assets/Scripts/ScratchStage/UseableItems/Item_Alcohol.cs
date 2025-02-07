using UnityEngine;

public class Item_Alcohol : MonoBehaviour, IUseable {
    [Header("References")]
    [SerializeField] Animator animatorController;

    void Start() {
        animatorController = GetComponent<Animator>();
    }

    public void UseItem() {
        Debug.Log("UseItem");
        animatorController.SetBool("isUsed", true);
        GetComponent<DragableItem>().isPlayingAnimation = true;
        gameObject.transform.position = GetComponent<DragableItem>().originPosition;
    }

    public void AnimNotifyDestroyGameObject() {
        Destroy(gameObject);
    }
}
