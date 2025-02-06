using UnityEditor.ShaderGraph.Serialization;
using UnityEngine;

public class CPR_FirstLungResuscitationHand : MonoBehaviour, IUseable {
    [Header("References")]
    [SerializeField] Animator animatorController;
    [SerializeField] GameObject secondHand;

    void Start() {
        animatorController = GetComponent<Animator>();
    }

    public void UseItem() {
        Debug.Log("First Lung Resuscitation Hand used!");
        //Play Animation
        animatorController.SetBool("isUsed", true);
        GetComponent<DragableItem>().isPlayingAnimation = true;
        GetComponent<DragableItem>().canDrag = false;
        transform.position = CPRStageStepManager.instance.noseHitbox.transform.position;
    }

    public void AnimNotifyDestroyGameObject() {
        GetComponent<Collider2D>().enabled = true;
        CPRStageCharacter.instance.OnCorrectItemForEachStep();
    }

    private void OnTriggerStay2D(Collider2D collision) {
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
