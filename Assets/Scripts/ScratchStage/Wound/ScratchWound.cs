using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class ScratchWound : MonoBehaviour
{
    
    [SerializeField] List<GameObject> itemForeachStep = new List<GameObject>();
   Enum_StageStep GetStageStep()
    {
        return ScratchStageStepManager.instance.thisScratchStageStep;
    }
}
