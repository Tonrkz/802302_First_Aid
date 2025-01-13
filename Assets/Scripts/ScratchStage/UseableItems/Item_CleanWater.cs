using UnityEngine;

public class Item_CleanWater : MonoBehaviour, IUseable
{
   public void UseItem()
    {
        Debug.Log("UseItem");
        Destroy(gameObject);
    }
}
