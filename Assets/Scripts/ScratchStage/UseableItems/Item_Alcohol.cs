using UnityEngine;

public class Item_Alcohol : MonoBehaviour, IUseable
{
    public void UseItem()
    {
        Debug.Log("UseItem");
        Destroy(gameObject);
    }
}
