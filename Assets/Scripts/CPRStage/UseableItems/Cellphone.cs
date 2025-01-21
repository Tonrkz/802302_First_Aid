using UnityEngine;

public class Cellphone : MonoBehaviour, IUseable {
    public void UseItem() {
        Debug.Log("Cellphone used!");
        //Play Animation
        //Play Sound
        //Destroy Object
        Destroy(gameObject);
    }
}
