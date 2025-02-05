using UnityEngine;

public class CPR_CheckForBreathingHand : MonoBehaviour, IUseable {
    [Header("Refferences")]
    [SerializeField] Animator animatorController;

    void Start() {
        animatorController = GetComponent<Animator>();
    }

    public void UseItem() {
        Debug.Log("Check For Breathing Hand used!");
        //Play Animation
        animatorController.SetBool("isUsed", true);
        GetComponent<DragableItem>().isPlayingAnimation = true;
        gameObject.transform.position = GetComponent<DragableItem>().originPosition;
    }

    public void AnimNotifyDestroyGameObject() {
        CPRStageCharacter.instance.OnCorrectItemForEachStep();
        Destroy(gameObject);
    }
}
