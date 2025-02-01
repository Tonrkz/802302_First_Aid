using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BurnWound : MonoBehaviour {
    [Header("References")]
    [SerializeField] BurnStageCharacter burnStageCharacter;

    [Header("Attributes")]
    [SerializeField] List<GameObject> itemForEachStep = new List<GameObject>();

    void Start() {
        burnStageCharacter = GetComponentInParent<BurnStageCharacter>();
    }

    void OnTriggerStay2D(Collider2D other) {
        if (!other.gameObject.GetComponent<DragableItem>().isDragging) {
            if (other.gameObject == itemForEachStep[(Byte)GetStageStep()]) {
                Debug.Log("Right Item");
                other.GetComponent<IUseable>().UseItem();
                ScoreManager.instance.AddScore();
                BurnStageStepManager.instance.DisplayStepText();
                burnStageCharacter.OnCorrectItemForEachStep();
            }
            else {
                Debug.Log("Wrong Item");
                ScoreManager.instance.SubtractScore();
                burnStageCharacter.OnWrongItem();
            }
        }
    }

    Enum_BurnStageStep GetStageStep() {
        return BurnStageStepManager.instance.currentStep;
    }
}