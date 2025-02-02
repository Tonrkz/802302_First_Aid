using UnityEngine;

public class Item_Cloth : MonoBehaviour, IUseable
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
    }

    public void AnimNotifyDestroyGameObject()
    {
        Destroy(gameObject);
    }
}
