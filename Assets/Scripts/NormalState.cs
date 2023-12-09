using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalState : PlayerBaseState
{
    [SerializeField]
    float _movementSpeed;

    private PlayerController _playerController;
    private bool _lockRotation = false;

    public override void EnterState(PlayerController playerController)
    {
        _playerController = playerController;
    }

    public override void ExitState()
    {
        
    }

    public override void UpdateState()
    {

    }

    public override void FixedUpdateState()
    {
        _playerController.RigidBody.MovePosition(new Vector3(_playerController.gameObject.transform.position.x + Input.GetAxis("Horizontal") * _movementSpeed, _playerController.gameObject.transform.position.y + Input.GetAxis("Vertical") * _movementSpeed, _playerController.gameObject.transform.position.z));
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
