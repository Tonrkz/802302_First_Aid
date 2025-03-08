using UnityEngine;

public class CPR_SecondHandCPR : MonoBehaviour, IUseable {
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
        transform.position = CPRMinigameManager.instance.hitboxCPR.GetComponentInChildren<SpriteRenderer>().gameObject.transform.position;
    }

    public void AnimNotifyDestroyGameObject() {
        CPRStageCharacter.instance.OnCorrectItemForEachStep();
        CPRMinigameManager.instance.hitboxCPR.GetComponentInChildren<SpriteRenderer>().color = new Color(1, 1, 1, 1);
    }
}
