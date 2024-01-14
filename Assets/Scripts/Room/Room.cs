using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    [SerializeField]
    BoxCollider2D _floorCollider;

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
        return Vector2.zero;
    }
}
