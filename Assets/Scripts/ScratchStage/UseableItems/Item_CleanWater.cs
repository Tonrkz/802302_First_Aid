using UnityEngine;

public class Item_CleanWater : MonoBehaviour, IUseable
{
    [Header("References")]
    [SerializeField] Animator animatorController;

    void Start()
    {
        animatorController = GetComponent<Animator>();
    }
    public void UseItem()
    {
        Debug.Log("UseItem");
        animatorController.SetBool("isUsed", true);
        ScratchStageStepManager.instance.OnUsedItem.Invoke();
        gameObject.transform.position = GetComponent<DragableItem>().originPosition;
    }
    public void AnimNotifyDestroyGameObject()
    {
        ScratchStageStepManager.instance.OnFinishedUsedItem.Invoke();
        Destroy(gameObject);
    }
}
