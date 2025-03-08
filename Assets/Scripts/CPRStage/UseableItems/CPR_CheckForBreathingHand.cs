using UnityEngine;

public class CPR_CheckForBreathingHand : MonoBehaviour, IUseable {
    [Header("References")]
    [SerializeField] Animator animatorController;

    void Start() {
        animatorController = GetComponent<Animator>();
    }

    public void UseItem() {
        Debug.Log("Check For Breathing Hand used!");
        //Play Animation
        animatorController.SetBool("isUsed", true);
        CPRStageStepManager.instance.OnUsedItem.Invoke();
        gameObject.transform.position = GetComponent<DragableItem>().originPosition;
    }

    public void AnimNotifyDestroyGameObject() {
        CPRStageCharacter.instance.OnCorrectItemForEachStep();
        Destroy(gameObject);
    }
}
