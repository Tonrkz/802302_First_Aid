using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ScratchWound : MonoBehaviour
{
    
    [SerializeField] List<GameObject> itemForeachStep = new List<GameObject>();

    private void OnTriggerStay2D(Collider2D other)
    {
        if (!other.gameObject.GetComponent<DragableItem>().isDragging)
        {
            if(other.gameObject == itemForeachStep[(Byte)GetStageStep()])
            {
                Debug.Log("Right Item");
                other.GetComponent<IUseable>().UseItem();
                ScratchStageStepManager.instance.UpdateState();
            }
            else
            {
                Debug.Log("Wrong Item");
            }

        }
    }
    Enum_StageStep GetStageStep()
    {
        return ScratchStageStepManager.instance.thisScratchStageStep;
    }

}
