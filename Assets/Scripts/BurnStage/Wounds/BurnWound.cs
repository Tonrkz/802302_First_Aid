using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BurnWound : MonoBehaviour {

    [Header("Attributes")]
    [SerializeField] List<GameObject> itemForEachStep = new List<GameObject>();

    Enum_BurnStageStep GetStageStep() {
        return BurnStageStepManager.instance.currentStep;
    }
}
