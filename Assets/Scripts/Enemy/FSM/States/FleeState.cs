using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FleeState : BaseState
{
    [SerializeField]
    int _maxTries;

    [SerializeField]
    float _movementSpeed;

    private EnemyController _enemyController;

    private Vector2 _targetPosition;
    private float _horizontalMovement, _verticalMovement;

    public override void EnterState(StateController stateController)
    {
        _enemyController = stateController as EnemyController;
        SetTarget();
    }

    public override void ExitState()
    {

    }

    public override void FixedUpdateState()
    {
        float horizontalVelocity = _horizontalMovement * _movementSpeed;
        float verticalVelocity = _verticalMovement * _movementSpeed;
        _enemyController.RigidBody.velocity = new Vector2(horizontalVelocity, verticalVelocity);
    }

    public override void OnCollisionEnter2DState(Collision2D collision)
    {

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
        bool targetSet = false;
        int tries = 0;
        while (!targetSet && tries < _maxTries)
        {
            _targetPosition = _enemyController.GameController.AllRoomsController.GetRoomFromRoomID(_enemyController.GetCurrentRoomID()).GetRandomPointInRoom();
            float distanceToTarget = Vector2.Distance(_targetPosition, _enemyController.transform.position);
            if (_enemyController.SubjectiveRaycast2D(_targetPosition - (Vector2)_enemyController.transform.position, distanceToTarget).collider != null)
            {
                targetSet = true;
                Debug.Log(_enemyController + " found cover at " + _targetPosition);
            }
            tries++;
        }
    }
}
