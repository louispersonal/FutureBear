using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FleeStateDoneCondition : BaseCondition
{
    [SerializeField]
    FleeState _fleeState;

    public override bool ExitCondition(StateController stateController)
    {
        return _fleeState.ReachedTarget() || _fleeState.CollidedWithSomething;
    }
}
