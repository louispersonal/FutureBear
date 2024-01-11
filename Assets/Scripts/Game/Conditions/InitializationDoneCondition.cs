using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitializationDoneCondition : BaseCondition
{
    [SerializeField]
    InitializationState _initializationState;

    public override bool ExitCondition(StateController stateController)
    {
        return _initializationState.InitializationDone;
    }
}
