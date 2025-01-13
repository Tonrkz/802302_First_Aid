using UnityEngine;

public class Item_Betadine : MonoBehaviour, IUseable
{
    public void UseItem()
    {
        Debug.Log("UseItem");
        Destroy(gameObject);
    }
}
