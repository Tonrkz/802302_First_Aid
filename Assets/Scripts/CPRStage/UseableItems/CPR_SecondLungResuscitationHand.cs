using UnityEngine;

public class CPR_SecondLungResuscitationHand : MonoBehaviour, IUseable {
    [Header("References")]
    [SerializeField] Animator animatorController;

    void Start() {
        animatorController = GetComponent<Animator>();
    }

    public void UseItem() {
        Debug.Log("Check For Breathing Hand used!");
        //Play Animation
        animatorController.SetBool("isUsed", true);
        GetComponent<DragableItem>().isPlayingAnimation = true;
        transform.position = CPRStageStepManager.instance.noseHitbox.transform.position;
    }

    public void AnimNotifyDestroyGameObject() {
        CPRStageCharacter.instance.OnCorrectItemForEachStep();
    }
}
