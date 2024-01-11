using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateController : MonoBehaviour
{
    [SerializeField]
    BaseState _initialState;

    [SerializeField]
    BaseState _idleState;

    private BaseState _currentState;

    private BaseState _lastState;

    // Start is called before the first frame update
    protected virtual void Start()
    {
        ForceInitial();
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        _currentState.UpdateState();
        foreach (BaseCondition condition in _currentState.ConditionList)
        {
            if (condition.ExitCondition(this))
            {
                SwitchState(condition.NextState);
            }
        }
    }

    protected virtual void FixedUpdate()
    {
        _currentState.FixedUpdateState();
    }

    protected virtual void SwitchState(BaseState nextState)
    {
        _currentState.ExitState();
        _currentState = nextState;
        _currentState.EnterState(this);
    }

    protected virtual void OnCollisionEnter2D(Collision2D collision)
    {
        _currentState.OnCollisionEnter2DState(collision);
    }

    protected virtual void OnCollisionExit2D(Collision2D collision)
    {
        _currentState.OnCollisionExit2DState(collision);
    }

    public virtual void ForceIdle()
    {
        // here we pause the state machine by going idle
        _lastState = _currentState;
        _currentState = _idleState;
        _currentState.EnterState(this);
    }

    public virtual void ForceResumeLastState()
    {
        // here we resume the state machine from idle to the last state
        if (_lastState != null)
        {
            _currentState = _lastState;
            _currentState.EnterState(this);
        }

        else
        {
            ForceInitial();
        }
    }

    public virtual void ForceInitial()
    {
        _currentState = _initialState;
        _currentState.EnterState(this);
    }
}
