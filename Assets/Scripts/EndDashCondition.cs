using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndDashCondition : BaseCondition
{
    public override bool ExitCondition(PlayerController playerController)
    {
        return false;
    }
}
