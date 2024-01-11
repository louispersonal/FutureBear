using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseCondition : MonoBehaviour
{
    public BaseState NextState;

    public abstract bool ExitCondition(StateController stateController);
}
