using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackStateDoneCondition : BaseCondition
{
    [SerializeField]
    AttackState _attackState;

    public override bool ExitCondition(StateController stateController)
    {
        return _attackState.DoneAttacking;
    }
}
