using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleStateDoneCondition : BaseCondition
{
    public override bool ExitCondition(StateController stateController)
    {
        // can not leave idle organically, must be forced
        return false;
    }
}
