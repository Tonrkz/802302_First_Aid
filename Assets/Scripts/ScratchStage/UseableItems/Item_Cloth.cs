using UnityEngine;

public class Item_Cloth : MonoBehaviour, IUseable
{
    public void UseItem()
    {
        Debug.Log("UseItem");
        Destroy(gameObject);
    }
}
