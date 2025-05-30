using System.Collections;
using UnityEngine;

public class ScratchStageCharacter : MonoBehaviour {
    [Header("References")]
    [SerializeField] Animator animatorController;

    void Start() {
        animatorController = GetComponent<Animator>();
    }

    public void OnCorrectItemForEachStep() {
        animatorController.SetTrigger("isCorrect");
    }

    public void OnWrongItem() {
        animatorController.SetTrigger("isWrong");
        if (ScoreManager.instance.score > 0) {
            StartCoroutine(ScoreManager.instance.ShowWrongStepHUD());
        }
    }

    public void AnimNotifyUpdateStep() {
        byte currentStep = (byte)ScratchStageStepManager.instance.thisScratchStageStep;
        ScratchStageStepManager.instance.UpdateState();
        StartCoroutine(UpdateAnimLayer(currentStep));
    }

    IEnumerator UpdateAnimLayer(byte currentLayer) {
        yield return new WaitUntil(() => animatorController.GetCurrentAnimatorStateInfo(0).normalizedTime > 0 && animatorController.GetCurrentAnimatorStateInfo(0).IsName("Idle"));
        animatorController.SetLayerWeight(currentLayer, 0);
        animatorController.SetLayerWeight(currentLayer + 1, 1);

    }
}
