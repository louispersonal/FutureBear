using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    [SerializeField]
    BoxCollider2D _floorCollider;

    private int _roomID;
    public int RoomID
    {
        get { return _roomID; }
        set { _roomID = value; }
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool IsPointInRoom(Vector2 point)
    {
        return _floorCollider.OverlapPoint(point);
    }

    public Vector2 GetRandomPointInRoom()
    {
        // returns answer in World Space
        float width = _floorCollider.size.x;
        float height = _floorCollider.size.y;
        Vector2 randomPointInRoomSpace = new Vector2(Random.Range(-width / 2, width / 2), Random.Range(-height / 2, height / 2));
        return RoomPointToWorldPoint(randomPointInRoomSpace);
    }

    public Vector2 GetRandomPointInRoomWithBoundingPoint(Vector2 boundingPoint, Vector2 subjectPoint)
    {
        // bounding Point must be given in Room Space
        // we want to find a random point in the room such that the subject point would not pass the bounding point if it traveled towards the random point
        float width = _floorCollider.size.x;
        float height = _floorCollider.size.y;
        Vector2 difference = boundingPoint - subjectPoint;
        Vector2 result = Vector2.zero;
        result.x = (difference.x < 0) ? Random.Range(boundingPoint.x, width / 2) : Random.Range(-width / 2, boundingPoint.x);
        result.y = (difference.y < 0) ? Random.Range(boundingPoint.y, height / 2) : Random.Range(-height / 2, boundingPoint.y);
        return WorldPointToRoomPoint(result);
    }

    public Vector2 WorldPointToRoomPoint(Vector2 worldPoint)
    {
        // assuming the transform of the room is the origin
        return RotatePointAboutOrigin(worldPoint - (Vector2)_floorCollider.transform.position, -Mathf.Deg2Rad * _floorCollider.transform.eulerAngles.z);
    }

    public Vector2 RoomPointToWorldPoint(Vector2 roomPoint)
    {
        // assuming the transform of the room is the origin
        return RotatePointAboutOrigin(roomPoint, Mathf.Deg2Rad * _floorCollider.transform.eulerAngles.z) + (Vector2)_floorCollider.transform.position;
    }

    public Vector2 RotatePointAboutOrigin(Vector2 point, float angle)
    {
        return new Vector2((point.x * Mathf.Cos(angle) - point.y * Mathf.Sin(angle)), (point.y * Mathf.Cos(angle) + point.x * Mathf.Sin(angle)));
    }
}
