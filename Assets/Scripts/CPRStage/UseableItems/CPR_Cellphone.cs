using UnityEngine;

public class CPR_Cellphone : MonoBehaviour, IUseable {
    public void UseItem() {
        Debug.Log("Cellphone used!");
        //Play Animation
        //Play Sound
        //Destroy Object
        Destroy(gameObject);
    }
}
