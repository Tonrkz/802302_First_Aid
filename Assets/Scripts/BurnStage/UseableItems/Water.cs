using UnityEngine;

public class Water : MonoBehaviour, IUseable {
    public void UseItem() {
        Debug.Log("Water Used");
        Destroy(gameObject);
    }
}
