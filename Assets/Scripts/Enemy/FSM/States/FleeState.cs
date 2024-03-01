using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FleeState : BaseState
{
    [HideInInspector]
    public bool CollidedWithSomething;

    [SerializeField]
    int _maxTries;

    [SerializeField]
    float _movementSpeed;

    private EnemyController _enemyController;

    private Vector2 _targetPosition;
    private float _horizontalMovement, _verticalMovement;

    public override void EnterState(StateController stateController)
    {
        Debug.Log("Entering flee state");
        _enemyController = stateController as EnemyController;
        CollidedWithSomething = false;
        SetTarget();
    }

    public override void ExitState()
    {
        _enemyController.RigidBody.velocity = Vector2.zero;
    }

    public override void FixedUpdateState()
    {
        _enemyController.ZeroAllVelocities();
        float horizontalVelocity = _horizontalMovement * _movementSpeed;
        float verticalVelocity = _verticalMovement * _movementSpeed;
        _enemyController.RigidBody.velocity = new Vector2(horizontalVelocity, verticalVelocity);
    }

    public override void OnCollisionEnter2DState(Collision2D collision)
    {
        CollidedWithSomething = true;
    }

    public override void OnCollisionExit2DState(Collision2D collision)
    {

    }

    public override void UpdateState()
    {
        Vector2 currentToTarget = (_targetPosition - (Vector2)_enemyController.transform.position).normalized;
        _horizontalMovement = currentToTarget.x;
        _verticalMovement = currentToTarget.y;
    }

    private void SetTarget()
    {
        Vector2 playerPosition = _enemyController.GameController.PlayerController.transform.position;
        bool targetSet = false;
        int tries = 0;
        while (!targetSet && tries < _maxTries)
        {
            _targetPosition = _enemyController.GameController.AllRoomsController.GetRoomFromRoomID(_enemyController.GetCurrentRoomID()).GetRandomPointInRoomWithBoundingPoint(playerPosition, _enemyController.transform.position);
            float distanceToTarget = Vector2.Distance(_targetPosition, _enemyController.transform.position);
            if (_enemyController.SubjectiveRaycast2D(_targetPosition - (Vector2)_enemyController.transform.position, distanceToTarget).collider != null)
            {
                targetSet = true;
            }
            tries++;
        }
    }

    public bool ReachedTarget()
    {
        if (Vector2.Distance(_enemyController.transform.position, _targetPosition) <= _movementSpeed)
        {
            return true;
        }
        return false;
    }
}
