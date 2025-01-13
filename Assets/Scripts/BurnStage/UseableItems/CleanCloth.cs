using UnityEngine;

public class CleanCloth : MonoBehaviour, IUseable {
    public void UseItem() {
        Debug.Log("Cloth Used");
        Destroy(gameObject);
    }
}
