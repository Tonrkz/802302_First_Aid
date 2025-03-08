using UnityEngine;

public class GauzePad : MonoBehaviour, IUseable {
    public void UseItem() {
        Debug.Log("GauzePad Used");
        BurnStageStepManager.instance.OnUsedItem.Invoke();
        Destroy(gameObject);
    }
}