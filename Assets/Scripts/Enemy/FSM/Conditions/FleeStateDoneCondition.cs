using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FleeStateDoneCondition : BaseCondition
{
    public override bool ExitCondition(StateController stateController)
    {
        return false;
    }
}
