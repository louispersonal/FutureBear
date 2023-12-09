using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    PlayerBaseState _initialState;

    public Rigidbody2D RigidBody;

    private PlayerBaseState _currentState;

    // Start is called before the first frame update
    void Start()
    {
        _currentState = _initialState;
        _currentState.EnterState(this);
    }

    // Update is called once per frame
    void Update()
    {
        _currentState.UpdateState();
        foreach(BaseCondition condition in _currentState.ConditionList)
        {
            if (condition.ExitCondition(this))
            {
                SwitchState(condition.NextState);
            }
        }
    }

    void FixedUpdate()
    {
        _currentState.FixedUpdateState();
    }

    void SwitchState(PlayerBaseState nextState)
    {
        _currentState.ExitState();
        _currentState = nextState;
        _currentState.EnterState(this);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        _currentState.OnCollisionEnter2DState(collision);
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        _currentState.OnCollisionExit2DState(collision);
    }
}
