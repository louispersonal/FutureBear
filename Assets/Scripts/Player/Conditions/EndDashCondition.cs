using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndDashCondition : BaseCondition
{
    [SerializeField]
    DashState _dashState;

    public override bool ExitCondition(StateController stateController)
    {
        if (!_dashState.IsDashing)
        {
            return true;
        }
        return false;
    }
}
