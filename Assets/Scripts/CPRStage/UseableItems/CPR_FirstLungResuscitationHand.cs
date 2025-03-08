using UnityEngine;

public class CPR_FirstLungResuscitationHand : MonoBehaviour, IUseable {
    [Header("References")]
    [SerializeField] Animator animatorController;
    [SerializeField] Transform firstHandPoint;
    [SerializeField] GameObject secondHand;

    void Start() {
        animatorController = GetComponent<Animator>();
    }

    public void UseItem() {
        Debug.Log("First Lung Resuscitation Hand used!");
        //Play Animation
        animatorController.SetBool("isUsed", true);
        CPRStageStepManager.instance.OnUsedItem.Invoke();
        transform.position = firstHandPoint.position;
    }

    public void AnimNotifyDestroyGameObject() {
        GetComponent<Collider2D>().enabled = true;
        CPRStageCharacter.instance.OnCorrectItemForEachStep();
        GetComponent<DragableItem>().enabled = false;
    }

    private void OnTriggerStay2D(Collider2D collision) {
        if (CPRStageStepManager.instance.currentStep == Enum_CPRStageStep.SecondHandLungResuscitation) {
            if (collision.GetComponent<DragableItem>() != null && collision.gameObject == secondHand) {
                collision.GetComponent<IUseable>().UseItem();
            }
            else if (collision.GetComponent<DragableItem>() != null) {
                if (!collision.GetComponent<DragableItem>().isDragging) {
                    CPRStageStepManager.instance.OnStepWrong();
                }
            }
        }
    }
}
