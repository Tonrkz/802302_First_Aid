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
        BurnStageStepManager.instance.OnUsedItem.Invoke();
        gameObject.transform.position = GetComponent<DragableItem>().originPosition;
    }

    public void AnimNotifyDestroyGameObject() {
        BurnStageStepManager.instance.OnFinishedUsedItem.Invoke();
        Destroy(gameObject);
    }
}
