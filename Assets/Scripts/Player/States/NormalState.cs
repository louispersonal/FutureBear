using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalState : PlayerBaseState
{
    [SerializeField]
    float _movementSpeed;

    private PlayerController _playerController;
    private bool _lockRotation = false;
    private float _horizontalInput, _verticalInput;

    public override void EnterState(PlayerController playerController)
    {
        _playerController = playerController;
    }

    public override void ExitState()
    {
        
    }

    public override void UpdateState()
    {
        _horizontalInput = Input.GetAxisRaw("Horizontal");
        _verticalInput = Input.GetAxisRaw("Vertical");
    }

    public override void FixedUpdateState()
    {
        float horizontalVelocity = _horizontalInput * _movementSpeed;
        float verticalVelocity = _verticalInput * _movementSpeed;
        _playerController.RigidBody.velocity = new Vector2(horizontalVelocity, verticalVelocity);

        if (!_lockRotation)
        {
            RotateBody(_playerController);
        }
    }

    private void RotateBody(PlayerController playerController)
    {
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - playerController.transform.position;

        float angle = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg - 90f;

        playerController.RigidBody.rotation = angle;
    }

    public override void OnCollisionEnter2DState(Collision2D collision)
    {
        _lockRotation = true;
    }


    public override void OnCollisionExit2DState(Collision2D collision)
    {
        _lockRotation = false;
    }
}
