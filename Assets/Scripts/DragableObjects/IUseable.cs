using UnityEngine;

public interface IUseable {
    Vector2 originPosition { get; set; }
    void UseItem();
    void ResetPosition();
}
