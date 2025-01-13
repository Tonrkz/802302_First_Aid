using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BurnWound : MonoBehaviour {

    [Header("Attributes")]
    [SerializeField] List<GameObject> itemForEachStep = new List<GameObject>();

    void OnTriggerStay2D(Collider2D other) {
        if (!other.gameObject.GetComponent<DragableItem>().isDragging) {
            if (other.gameObject == itemForEachStep[(Byte)GetStageStep()]) {
                Debug.Log("Right Item");
                other.GetComponent<IUseable>().UseItem();
                BurnStageStepManager.instance.UpdateStep();
            }
            else {
                Debug.Log("Wrong Item");
            }
        }

        Enum_BurnStageStep GetStageStep() {
            return BurnStageStepManager.instance.currentStep;
        }
    }
}