using UnityEngine;

public class CPR_FirstHandCPR : MonoBehaviour, IUseable {
    [Header("References")]
    [SerializeField] Animator animatorController;
    [SerializeField] GameObject secondHand;

    void Start() {
        animatorController = GetComponent<Animator>();
    }

    public void UseItem() {
        Debug.Log("Check For Breathing Hand used!");
        //Play Animation
        animatorController.SetBool("isUsed", true);
        GetComponent<DragableItem>().isPlayingAnimation = true;
        GetComponent<DragableItem>().canDrag = false;
        transform.position = CPRMinigameManager.instance.hitboxCPR.transform.position;
    }

    public void AnimNotifyDestroyGameObject() {
        GetComponent<Collider2D>().enabled = true;
        CPRStageCharacter.instance.OnCorrectItemForEachStep();
    }

    private void OnTriggerStay2D(Collider2D collision) {
        if (CPRStageStepManager.instance.currentStep == Enum_CPRStageStep.SecondHandCPR) {
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
