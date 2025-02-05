using UnityEngine;

public class CPR_CheckForBreathingHand : MonoBehaviour, IUseable {
    [Header("Refferences")]
    [SerializeField] Animator animatorController;
    [SerializeField] AudioClip phoneSFX;

    void Start() {
        animatorController = GetComponent<Animator>();
    }

    public void UseItem() {
        Debug.Log("Check For Breathing Hand used!");
        //Play Animation
        animatorController.SetBool("isUsed", true);
        //Play Sound
        SFXManager.instance.PlaySFXClip(phoneSFX, transform, 1f);
    }

    public void AnimNotifyUpdateStep() {
        CPRStageCharacter.instance.OnCorrectItemForEachStep();
    }
}
