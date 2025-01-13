using UnityEngine;

public class Item_Soap : MonoBehaviour, IUseable
{
    public void UseItem()
    {
        Debug.Log("UseItem");
        Destroy(gameObject);
    }
}
