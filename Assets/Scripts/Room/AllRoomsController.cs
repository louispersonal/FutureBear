using System.Collections;
using System.Collections.Generic;
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
}
