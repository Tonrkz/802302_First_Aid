using UnityEngine;

public class Item_Alcohol : MonoBehaviour, IUseable
{
    Vector2 originPosition;
    DragableItem dragableItemScript;

    public Vector2 OriginPosition { get => originPosition; set => value = originPosition; }

    void Awake()
    {
        dragableItemScript = GetComponent<DragableItem>();
        originPosition = transform.position;
    }


    void Update()
    {
        if (!dragableItemScript.isDragging)
        {
            ResetPosition();
        }
    }



    public void ResetPosition()
    {
        transform.position = originPosition;
    }

    public void UseItem()
    {
        throw new System.NotImplementedException();
    }
}
