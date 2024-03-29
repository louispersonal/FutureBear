using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashState : BaseState
{
    [SerializeField]
    float _dashSpeed;

    [SerializeField]
    float _dashTime;

    private PlayerController _playerController;

    public bool IsDashing;

    public override void EnterState(StateController stateController)
    {
        _playerController = stateController as PlayerController;
        IsDashing = true;
        StartCoroutine(DashCoroutine());
        _playerController.Animator.SetTrigger("Dash");
    }

    public override void ExitState()
    {

    }

    public override void FixedUpdateState()
    {

    }

    public override void OnCollisionEnter2DState(Collision2D collision)
    {
        IsDashing = false;
        StopCoroutine(DashCoroutine());
    }

    public override void OnCollisionExit2DState(Collision2D collision)
    {

    }

    public override void UpdateState()
    {

    }

    private IEnumerator DashCoroutine()
    {
        _playerController.RigidBody.velocity = transform.up * _dashSpeed;
        yield return new WaitForSeconds(_dashTime);
        _playerController.RigidBody.velocity = Vector2.zero;
        IsDashing = false;
    }
}
