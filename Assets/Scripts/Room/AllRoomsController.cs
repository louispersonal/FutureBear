using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using UnityEngine;

public class AllRoomsController : MonoBehaviour
{
    List<Room> _rooms;

    public List<Room> Rooms
    {
        get { return _rooms; }
    }

    // Start is called before the first frame update
    void Start()
    {
        _rooms = new List<Room>();
        Room[] roomArray = FindObjectsOfType<Room>();
        _rooms.AddRange(roomArray.ToList());
        SetRoomIDs();
    }

    void SetRoomIDs()
    {
        for (int i = 0; i < _rooms.Count; i++)
        {
            _rooms[i].RoomID = i;
        }
    }

    public int GetRoomIDForPoint(Vector2 point)
    {
        for (int i = 0; i < _rooms.Count; i++)
        {
            if (_rooms[i].IsPointInRoom(point))
            {
                return _rooms[i].RoomID;
            }
        }
        Debug.Log("Point is not in room");
        return -1;
    }

    public Room GetRoomFromRoomID(int roomID)
    {
        for (int i = 0; i < _rooms.Count; i++)
        {
            if (_rooms[i].RoomID == roomID)
            {
                return _rooms[i];
            }
        }
        Debug.LogError("No room found for ID " + roomID);
        return null;
    }
}
