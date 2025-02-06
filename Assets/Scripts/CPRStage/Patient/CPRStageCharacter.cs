using System.Collections;
using UnityEngine;

public class CPRStageCharacter : MonoBehaviour {
    public static CPRStageCharacter instance;

    [Header("References")]
    [SerializeField] Animator animatorController;

    private void Awake() {
        if (instance == null) {
            instance = this;
        }
        else {
            Destroy(gameObject);
        }
    }

    void Start() {
        animatorController = GetComponent<Animator>();
    }

    public void OnCorrectItemForEachStep() {
        animatorController.SetTrigger("isCorrect");
    }

    public void OnHelpBreathing() {
        animatorController.SetBool("isHelpingBreath", true);
    }

    public void OnStopHelpBreathing() {
        animatorController.SetBool("isHelpingBreath", false);
    }

    public void OnWrongItem() {
        animatorController.SetTrigger("isWrong");
    }

    public void AnimNotifyUpdateStep() {
        byte currentStep = (byte)CPRStageStepManager.instance.currentStep;
        StartCoroutine(UpdateAnimLayer(currentStep));
        CPRStageStepManager.instance.OnStepCompleted();
    }

    IEnumerator UpdateAnimLayer(byte currentLayer) {
        yield return new WaitUntil(() => animatorController.GetCurrentAnimatorStateInfo(0).normalizedTime > 0 && animatorController.GetCurrentAnimatorStateInfo(0).IsName("Idle"));
            animatorController.SetLayerWeight(currentLayer, 0);
            animatorController.SetLayerWeight(currentLayer + 1, 1);

    }
}
