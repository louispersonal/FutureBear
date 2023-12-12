using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndDashCondition : BaseCondition
{
    [SerializeField]
    DashState _dashState;

    public override bool ExitCondition(PlayerController playerController)
    {
        if (!_dashState.IsDashing)
        {
            return true;
        }
        return false;
    }
}
