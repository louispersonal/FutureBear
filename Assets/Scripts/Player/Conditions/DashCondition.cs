using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashCondition : BaseCondition
{
    public override bool ExitCondition(PlayerController playerController)
    {
        if (Input.GetButtonDown("Fire2"))
        {
            return true;
        }
        return false;
    }
}
