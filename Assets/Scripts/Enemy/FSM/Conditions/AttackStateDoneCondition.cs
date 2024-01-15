using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackStateDoneCondition : BaseCondition
{
    public override bool ExitCondition(StateController stateController)
    {
        return false;
    }
}
