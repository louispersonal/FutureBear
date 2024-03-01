using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalState : BaseState
{
    [SerializeField]
    float _movementSpeed;

    [SerializeField]
    float _shootForce;

    private PlayerController _playerController;
    private GameController _gameController;
    private bool _lockRotation = false;
    private float _horizontalInput, _verticalInput;

    public override void EnterState(StateController stateController)
    {
        _playerController = stateController as PlayerController;
        _gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        _playerController.CanOpenNotepad = true;
    }

    public override void ExitState()
    {
        _playerController.CanOpenNotepad = false;
    }

    public override void UpdateState()
    {
        _horizontalInput = Input.GetAxisRaw("Horizontal");
        _verticalInput = Input.GetAxisRaw("Vertical");
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
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

    private void Shoot()
    {
        BaseProjectile projectile = _gameController.ProjectilePoolController.GetAvailableProjectile();
        projectile.transform.rotation = _playerController.transform.rotation;
        projectile.transform.position = _playerController.transform.position;
        projectile.gameObject.SetActive(true);
        projectile.RigidBody.AddForce(_shootForce * _playerController.transform.up);
    }
}
