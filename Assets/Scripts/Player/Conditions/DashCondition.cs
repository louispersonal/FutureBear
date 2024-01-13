using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashCondition : BaseCondition
{
    public override bool ExitCondition(StateController stateController)
    {
        if (Input.GetButtonDown("Fire2"))
        {
            return true;
        }
        return false;
    }
}
