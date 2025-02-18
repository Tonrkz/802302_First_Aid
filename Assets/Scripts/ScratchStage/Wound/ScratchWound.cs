using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ScratchWound : MonoBehaviour
{
    [Header("Audio")]
    [SerializeField] AudioClip correctItemSFX;
    [SerializeField] AudioClip wrongItemSFX;
    
    [SerializeField] List<GameObject> itemForeachStep = new List<GameObject>();
    [SerializeField] ScratchStageCharacter scratchStageCharacter;

    private void Start()
    {
        scratchStageCharacter = GetComponentInParent<ScratchStageCharacter>();
    }


    private void OnTriggerStay2D(Collider2D other)
    {
        if (!other.gameObject.GetComponent<DragableItem>().isDragging)
        {
            if(other.gameObject == itemForeachStep[(Byte)GetStageStep()])
            {
                SFXManager.instance.PlaySFXClip(correctItemSFX, transform, 1f);
                Debug.Log("Right Item");
                scratchStageCharacter.OnCorrectItemForEachStep();
                other.GetComponent<IUseable>().UseItem();
                ScoreManager.instance.AddScore();
                ScratchStageStepManager.instance.DisplayStepText();
            }
            else
            {
                SFXManager.instance.PlaySFXClip(wrongItemSFX, transform, 1f);
                Debug.Log("Wrong Item");
                scratchStageCharacter.OnWrongItem();
                ScoreManager.instance.SubtractScore();
            }

        }
    }
    Enum_ScratchStageStep GetStageStep()
    {
        return ScratchStageStepManager.instance.thisScratchStageStep;
    }

}
