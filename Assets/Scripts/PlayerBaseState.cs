using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerBaseState : MonoBehaviour
{
    public List<BaseCondition> ConditionList;

    public abstract void UpdateState();

    public abstract void FixedUpdateState();

    public abstract void EnterState(PlayerController playerController);

    public abstract void ExitState();

    public abstract void OnCollisionEnter2DState(Collision2D collision);

    public abstract void OnCollisionExit2DState(Collision2D collision);
}
