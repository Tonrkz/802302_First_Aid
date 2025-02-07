using UnityEngine;

public class CPR_Cellphone : MonoBehaviour, IUseable {
    [Header("Refferences")]
    [SerializeField] Animator animatorController;
    [SerializeField] AudioClip phoneSFX;

    void Start() {
        animatorController = GetComponent<Animator>();
    }

    public void UseItem() {
        Debug.Log("Cellphone used!");
        //Play Animation
        animatorController.SetBool("isUsed", true);
        GetComponent<DragableItem>().isPlayingAnimation = true;
        gameObject.transform.position = GetComponent<DragableItem>().originPosition;
        //Play Sound
        SFXManager.instance.PlaySFXClip(phoneSFX, transform, 1f);
    }

    public void AnimNotifyDestroyGameObject() {
        CPRStageCharacter.instance.OnCorrectItemForEachStep();
        Destroy(gameObject);
    }
}
