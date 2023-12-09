using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseCondition : MonoBehaviour
{
    public PlayerBaseState NextState;

    public abstract bool ExitCondition(PlayerController playerController);
}
