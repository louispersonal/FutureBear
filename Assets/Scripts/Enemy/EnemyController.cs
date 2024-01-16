using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : StateController   
{
    [HideInInspector]
    public GameController GameController;

    public Rigidbody2D RigidBody;

    public float LineOfSightRange;

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


    public void FacePlayer()
    {
        Vector3 difference = GameController.PlayerController.transform.position - this.transform.position;

        float angle = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg - 90f;

        RigidBody.rotation = angle;
    }
}
