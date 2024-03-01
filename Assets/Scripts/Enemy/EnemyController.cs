using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : StateController   
{
    [HideInInspector]
    public GameController GameController;

    public Rigidbody2D RigidBody;

    public float LineOfSightRange;

    [SerializeField]
    float _rotationSpeed;

    protected override void Start()
    {
        GameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();

        base.Start();
    }

    public int GetCurrentRoomID()
    {
        return GameController.AllRoomsController.GetRoomIDForPoint(this.transform.position);
    }

    public RaycastHit2D SubjectiveRaycast2D(Vector2 direction, float distance)
    {
        return Physics2D.Raycast(this.transform.position, direction, distance);
    }

    public float DistanceFromPlayer()
    {
        return Vector2.Distance(GameController.PlayerController.transform.position, this.transform.position);
    }


    public void RotateTowardsFacePlayer()
    {
        Vector2 difference = GameController.PlayerController.transform.position - this.transform.position;

        float relativeAngle = Vector2.SignedAngle(this.transform.up, difference);

        if (Mathf.Abs(relativeAngle) < _rotationSpeed * Time.deltaTime)
        {
            RigidBody.rotation = RigidBody.rotation + relativeAngle;
        }

        else
        {
            RigidBody.rotation = RigidBody.rotation + (Mathf.Sign(relativeAngle) * _rotationSpeed * Time.deltaTime);
        }
        Debug.Log("rotating " + relativeAngle);
    }

    public bool IsFacingPlayer()
    {
        Vector3 difference = GameController.PlayerController.transform.position - this.transform.position;

        float angle = Vector2.SignedAngle(this.transform.up, difference);

        return angle == 0;
    }
}
