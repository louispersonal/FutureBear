using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoToAttackStateCondition : BaseCondition
{
    [SerializeField]
    DecisionState _decisionState;

    public override bool ExitCondition(StateController stateController)
    {
        return _decisionState.GoToAttackState;
    }
}
