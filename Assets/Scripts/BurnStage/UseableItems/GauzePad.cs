using UnityEngine;

public class GauzePad : MonoBehaviour, IUseable {
    public void UseItem() {
        Debug.Log("GauzePad Used");
        Destroy(gameObject);
    }
}