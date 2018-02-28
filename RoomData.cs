using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomData : MonoBehaviour {

	public Vector3 BottomLeft;
	public Vector3 TopRight;

	public Vector2 roomCenter;
	public Vector2 roomSize;

	public Bounds AABB;

	//private List<Vector3> OpenDoors;

	// Use this for initialization
	void Start ()
	{
		roomCenter.x = (int)(BottomLeft.x + TopRight.x) / 2;
		roomCenter.y = (int)(BottomLeft.y + TopRight.y) / 2;
		Debug.Log(BottomLeft);
		Debug.Log(TopRight);
		Debug.Log(roomCenter);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public Vector2 CreateJitterPos(RoomData room)
	{
		Vector2 tempPos;

		int xJitter = (int)room.roomSize.x * Random.Range(0, 2) * 2 - 1;
		int yJitter = (int)room.roomSize.y * Random.Range(0, 2) * 2 - 1;

		tempPos.x = room.roomCenter.x + xJitter;
		tempPos.y = room.roomCenter.y + yJitter;

		return tempPos;
	}
}
