using UnityEngine;
using System.Collections.Generic;

public class Map : MonoBehaviour 
{
	public GameObject hWall;
	public GameObject vWall;
	public GameObject player;
	public GameObject floorPre2;

	Dictionary<Vector2, Room> map = new Dictionary<Vector2, Room>();
	Dictionary<Vector2, bool> doors = new Dictionary<Vector2, bool>();

	bool roomConstancy = true;
	int roomWidth = 31;
	int roomLength = 25;
	
	void Start()
	{
		//Loads a room, and a room adjacent to it at the start
		LoadRoom (0, 0);
		//LoadRoom (0,1);
		//LoadRoom (1,1);
		LoadRoom (1,0);
	}
	
	void Update () 
	{
		LoadSurroundings (GetArea ());
		//Debug.Log (GetArea ().x + " " + GetArea ().y);
	}
	
	void LoadRoom(int x, int y)
	{
		if (map.ContainsKey(new Vector2(x, y)) == false)
		{
			//This array determines whether the room being created has a
			//door in each of the cardinal directions
			if (doors.ContainsKey(new Vector2(x, y + 0.5f)) == false)
			{  
				if (Random.value > 0.25f)
				{
					doors[new Vector2(x, y + 0.5f)] = true;
				}
				else
				{
					doors[new Vector2(x, y + 0.5f)] = false;
				}
			}

			if (doors.ContainsKey(new Vector2(x + 0.5f, y)) == false)
			{
				if (Random.value > 0.25f)
				{
					doors[new Vector2(x + 0.5f, y)] = true;
				}
				else
				{
					doors[new Vector2(x + 0.5f, y)] = false;
				}
			}

			if (doors.ContainsKey(new Vector2(x, y - 0.5f)) == false)
			{
				if (Random.value > 0.25f)
				{
					doors[new Vector2(x, y - 0.5f)] = true;
				}
				else
				{
					doors[new Vector2(x, y - 0.5f)] = false;
				}
			}

			if (doors.ContainsKey(new Vector2(x - 0.5f, y)) == false)
			{
				if (Random.value > 0.25f)
				{
					doors[new Vector2(x - 0.5f, y)] = true;
				}
				else
				{
					doors[new Vector2(x - 0.5f, y)] = false;
				}
			}

			//Creates a new room, and stores it in the 'map' dictionary
			map[new Vector2(x, y)] = new Room(x, y, roomWidth, roomLength, floorPre2);

			//This statement creates the walls that surround the room
			for (int i = 0; i < 7; i++)
			{
				if (doors[new Vector2(x, y + 0.5f)] == true && i == 3)
				{
					
				}
				else
				{
					Instantiate (hWall, new Vector3((x * roomWidth) - (roomWidth / 2) + 2.2f + i * 4.25f, (y * roomLength) + (roomLength / 2) + 2, 0), Quaternion.identity);
				}
			}

			for (int i = 0; i < 9; i++)
			{
				if (doors[new Vector2(x + 0.5f, y)] == true && (i >= 3 && i <= 5))
				{
					
				}
				else
				{
					Instantiate (vWall, new Vector3((x * roomWidth) + (roomWidth / 2) + 0.5f, (y * roomLength) - (roomLength / 2) + 3 + i * 2.6f, 0), Quaternion.identity);
				}
			}

			for (int i = 0; i < 9; i++)
			{
				if (doors[new Vector2(x - 0.5f, y)] == true && (i >= 3 && i <= 5))
				{
					
				}
				else
				{
					Instantiate (vWall, new Vector3((x * roomWidth) - (roomWidth / 2) - 0.45f, (y * roomLength) - (roomLength / 2) + 3 + i * 2.6f, 0), Quaternion.identity);
				}
			}

			for (int i = 0; i < 7; i++)
			{
				if (doors[new Vector2(x, y - 0.5f)] == true && i == 3)
				{
					
				}
				else
				{
					Instantiate (hWall, new Vector3((x * roomWidth) - (roomWidth / 2) + 2.2f + i * 4.25f, (y * roomLength) - (roomLength / 2) + 1, 0), Quaternion.identity);
				}
			}
		}
	}
	
	Vector2 GetArea()
	{
		//Fancy math to determine what the key for the current room is
		int x;
		int y;
		
		if (player.transform.position.x <= 0)
		{
			x = (int)((player.transform.position.x + (player.transform.position.x % roomWidth)) / (roomWidth));
		}
		else
		{
			x = (int)(((player.transform.position.x + roomWidth / 2) - ((player.transform.position.x + roomWidth / 2) % roomWidth)) / (roomWidth));
		}
		
		if (player.transform.position.y <= 0)
		{
			y = (int)((player.transform.position.y + (player.transform.position.y % roomLength)) / (roomLength));
		}
		else
		{
			y = (int)(((player.transform.position.y + roomLength / 2) - ((player.transform.position.y + roomLength / 2) % roomLength)) / (roomLength));
		}
		
		return new Vector2(x, y);
	}
	
	void LoadSurroundings(Vector2 area)
	{
		//This loads adjacent rooms that are connected to the present room  by doors
		if (doors[new Vector2(area.x, area.y + 0.5f)] == true)
		{
			LoadRoom ((int)(area.x), (int)(area.y + 1));
		}
		if (doors[new Vector2(area.x + 0.5f, area.y)] == true)
		{
			LoadRoom ((int)(area.x + 1), (int)(area.y));
		}
		if (doors[new Vector2(area.x, area.y - 0.5f)] == true)
		{
			LoadRoom ((int)(area.x), (int)(area.y - 1));
		}
		if (doors[new Vector2(area.x - 0.5f, area.y)] == true)
		{
			LoadRoom ((int)(area.x - 1), (int)(area.y));
		}
	}
}