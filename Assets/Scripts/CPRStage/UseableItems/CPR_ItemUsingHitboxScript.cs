using UnityEngine;

public class CPR_ItemUsingHitboxScript : MonoBehaviour {
    [Header("References")]
    [SerializeField] GameObject phone;

    [Header("Audio")]
    [SerializeField] AudioClip wrongItemSFX;

    private void OnTriggerStay2D(Collider2D other) {
        switch (CPRStageStepManager.instance.currentStep) {
            case Enum_CPRStageStep.StepTwo: // Call for ambulance
                if (other.GetComponent<DragableItem>() != null) {
                    if (!other.GetComponent<DragableItem>().isDragging && other.gameObject == phone) {
                        other.gameObject.GetComponent<IUseable>().UseItem();
                    }
                    else if (!other.GetComponent<DragableItem>().isDragging) {
                        SFXManager.instance.PlaySFXClip(wrongItemSFX, transform, 1f);
                        CPRStageCharacter.instance.OnWrongItem();
                        ScoreManager.instance.SubtractScore();
                    }
                }
                break;
            default:
                if (other.GetComponent<DragableItem>() != null) {
                    if (!other.GetComponent<DragableItem>().isDragging) {
                        SFXManager.instance.PlaySFXClip(wrongItemSFX, transform, 1f);
                        CPRStageCharacter.instance.OnWrongItem();
                        ScoreManager.instance.SubtractScore();
                    }
                }
                break;
        }
    }
}
