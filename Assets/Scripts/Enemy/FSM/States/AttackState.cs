using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : BaseState
{
    [HideInInspector]
    public bool DoneAttacking;

    private EnemyController _enemyController;

    [SerializeField]
    float _shootForce;

    [SerializeField]
    float _shootDelay;

    private bool delayingShoot;

    public override void EnterState(StateController stateController)
    {
        Debug.Log("Entering attack state");
        _enemyController = stateController as EnemyController;
        delayingShoot = false;
        DoneAttacking = false;
    }

    public override void ExitState()
    {

    }

    public override void FixedUpdateState()
    {
        _enemyController.ZeroAllVelocities();
        _enemyController.RotateTowardsFacePlayer();
    }

    public override void OnCollisionEnter2DState(Collision2D collision)
    {

    }

    public override void OnCollisionExit2DState(Collision2D collision)
    {

    }

    public override void UpdateState()
    {
        if ( !delayingShoot && _enemyController.IsFacingPlayer() )
        {
            StartCoroutine(ShootDelay());
            Shoot();
            if (Random.Range(0f, 1f) < 0.3)
            {
                DoneAttacking = true;
            }
        }
    }

    public void Shoot()
    {
        BaseProjectile projectile = _enemyController.GameController.ProjectilePoolController.GetAvailableProjectile();
        projectile.gameObject.SetActive(true);
        projectile.RigidBody.rotation = _enemyController.RigidBody.rotation;
        projectile.RigidBody.position = _enemyController.RigidBody.position;
        projectile.RigidBody.velocity = _enemyController.RigidBody.velocity;
        projectile.RigidBody.AddForce(_shootForce * _enemyController.RigidBody.transform.up);
    }

    private IEnumerator ShootDelay()
    {
        yield return new WaitForSeconds(_shootDelay);
    }
}
