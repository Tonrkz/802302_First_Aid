using UnityEngine;

public class CPR_SecondLungResuscitationHand : MonoBehaviour, IUseable {
    [Header("References")]
    [SerializeField] Animator animatorController;
    [SerializeField] Transform secondHandPoint;

    void Start() {
        animatorController = GetComponent<Animator>();
    }

    public void UseItem() {
        Debug.Log("Check For Breathing Hand used!");
        //Play Animation
        animatorController.SetBool("isUsed", true);
        CPRStageStepManager.instance.OnUsedItem.Invoke();
        transform.position = secondHandPoint.position;
    }

    public void AnimNotifyDestroyGameObject() {
        CPRStageCharacter.instance.OnCorrectItemForEachStep();
    }
}
