using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitializationState : BaseState
{
    public bool InitializationDone = false;

    public override void EnterState(StateController stateController)
    {
        InitializationDone = true;
    }

    public override void ExitState()
    {

    }

    public override void FixedUpdateState()
    {

    }

    public override void OnCollisionEnter2DState(Collision2D collision)
    {

    }

    public override void OnCollisionExit2DState(Collision2D collision)
    {

    }

    public override void UpdateState()
    {

    }
}
