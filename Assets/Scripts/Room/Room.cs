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
        float width = _floorCollider.size.x;
        float height = _floorCollider.size.y;
        Vector2 randomPointFromCenterUnrotated = new Vector2(Random.Range(-width / 2, width / 2), Random.Range(-height / 2, height / 2));
        return RotatePointAboutOrigin(randomPointFromCenterUnrotated, Mathf.Deg2Rad * _floorCollider.transform.eulerAngles.z) + (Vector2)_floorCollider.transform.position;
    }

    public Vector2 RotatePointAboutOrigin(Vector2 point, float angle)
    {
        return new Vector2((point.x * Mathf.Cos(angle) - point.y * Mathf.Sin(angle)), (point.y * Mathf.Cos(angle) + point.x * Mathf.Sin(angle)));
    }
}
