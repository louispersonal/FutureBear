using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecisionState : BaseState
{
    [HideInInspector]
    public bool GoToAttackState;

    [HideInInspector]
    public bool GoToFleeState;

    public override void EnterState(StateController stateController)
    {
        Debug.Log("Entering decision state");
        GoToAttackState = false;
        GoToFleeState = false;
        DecideOnNextState();
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

    public void DecideOnNextState()
    {
        if (Random.Range(0f, 1f) < 0.2)
        {
            GoToFleeState = true;
        }
        else
        {
            GoToAttackState = true;
        }
    }
}
