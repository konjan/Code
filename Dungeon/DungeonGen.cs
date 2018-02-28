using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonGen : MonoBehaviour
{ 
	public float BlockDistance = 1.0f;
	public int GridSize = 5;
	public int roomcount;
	public float roomSize = 5;

	public List<RoomData> Rooms = new List<RoomData>();

	private Bounds GridBounds;
	public GameObject GridSect;

	// Use this for initialization
	void Start ()
	{
		roomcount = Random.Range(2, 5);
		GridBounds.min.Set(0, 0, 0);
		GridBounds.max.Set(GridSize, 0, GridSize);


		//Setup the grid and setthe colours
		//Setup BSP tree
		GridSetup();

		//Room loop
		//for(int i = 0; i < 15; i++)
		//{ 
		//	Vector2 tempSize = new Vector2((int)Random.Range(3, 5), (int)Random.Range(3, 5));
		//
		//	GenerateRoom(tempSize);
		//}
	}
	
	// Update is called once per frame
	void Update ()
	{

	}

	private void GridSetup()
	{
		for (int i = 0; i < GridSize; i++)
		{
			for (int j = 0; j < GridSize; j++)
			{
				//getting the modulus if the index to use for the grid colour
				int k = (i + j) % 2;
				
				GameObject G = Resources.Load("GridSect") as GameObject;

				G.name = ("Grid" + i + "//" + j);

				GridSection TempAccess = G.GetComponent<GridSection>();
				TempAccess.TileSection = k;

				GameObject.Instantiate(G, new Vector3(i * roomSize, 0, j * roomSize), Quaternion.identity);
			}
		}
	}

	//Generates a Vector 2 to replicate the position of the room within the grid.
	//private void GenerateRoom(Vector2 size)
	//{
	//	RoomData tempRD = new RoomData();
	//	tempRD.roomSize = size;
	//	Vector2 pos = new Vector2();
	//	bool failed = false;
	//
	//	//if there aren't any rooms in the dungeon yet.
	//
	//	if (Rooms.Count == 0)
	//	{
	//		pos.x = Mathf.RoundToInt(GridSize / 2 + Random.Range(-2, 3));
	//		pos.y = Mathf.RoundToInt(GridSize / 2 + Random.Range(-2, 3));
	//	}
	//	else
	//	{
	//		int roomRandom = Random.Range(0, Rooms.Count);
	//
	//		pos = tempRD.CreateJitterPos(Rooms[roomRandom]);
	//
	//		//do
	//		//{
	//		//	pos = tempRD.CreateJitterPos(Rooms[roomRandom]);
	//		//} while (!GridBounds.Contains(new Vector3(pos.x, 0, pos.y)) && !GridBounds.Contains(new Vector3(pos.x + size.x, 0, pos.y + size.y)));
	//	}
	//
	//
	//	tempRD.BottomLeft = new Vector3((int)pos.x, 0, (int)pos.y);
	//	tempRD.TopRight = new Vector3((int)pos.x + (int)size.x, 0, (int)pos.y + (int)size.y);
	//	tempRD.AABB.min = new Vector3(tempRD.BottomLeft.x - .5f, 0, tempRD.BottomLeft.y - .5f);
	//	tempRD.AABB.max = new Vector3(tempRD.TopRight.x + .5f, 0, tempRD.TopRight.y + .5f); ;
	//	
	//	if (failed == false)
	//		AddRoom(tempRD);
	//}

	//private void AddRoom(RoomData rd)
	//{
	//	Debug.Log(rd.BottomLeft + "//" + rd.TopRight);
	//	for (int i = (int)rd.BottomLeft.x; i < (int)rd.TopRight.x; i++)
	//	{
	//		for (int j = (int)rd.BottomLeft.z; j < (int)rd.TopRight.z; j++)
	//		{
	//			GridSection GS = GameObject.Find("Grid" + i + "//" + j + "(Clone)").GetComponent<GridSection>();
	//
	//
	//			if (GS.isActive == false)
	//			{
	//				GS.isActive = true;
	//				GS.m_tileType = TileType.Room;
	//			}
	//		}
	//	}
	//	Rooms.Add(rd);
	//}

	//private bool RoomIntersects(RoomData RD)
	//{
	//	foreach (RoomData rd in Rooms)
	//	{
	//		if (RD.AABB.Intersects(rd.AABB))
	//		{
	//			Debug.Log("intersects");
	//			return true;
	//		}
	//	}
	//
	//	return false;
	//}

	private void createEntrance()
	{

	}
}