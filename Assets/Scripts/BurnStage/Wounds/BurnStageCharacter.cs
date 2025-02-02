using System.Collections;
using UnityEngine;

public class BurnStageCharacter : MonoBehaviour {
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
    }

    public void AnimNotifyUpdateStep() {
        byte currentStep = (byte)BurnStageStepManager.instance.currentStep;
        BurnStageStepManager.instance.UpdateStep();
        StartCoroutine(UpdateAnimLayer(currentStep));
    }

    IEnumerator UpdateAnimLayer(byte currentLayer) {
        yield return new WaitUntil(() => animatorController.GetCurrentAnimatorStateInfo(0).normalizedTime > 0 && animatorController.GetCurrentAnimatorStateInfo(0).IsName("Idle"));
            animatorController.SetLayerWeight(currentLayer, 0);
            animatorController.SetLayerWeight(currentLayer + 1, 1);
        
    }
}
