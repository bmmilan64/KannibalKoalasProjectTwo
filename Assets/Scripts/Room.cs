using UnityEngine;
using System.Collections;

public class Room
{
	private Vector3 location;
	public int mapX;
	public int mapY;

	private GameObject floor;
	private Vector3 floorScale;
	public GameObject floorPre;

	public Room (int x, int y, int width, int length, GameObject floorPre) 
	{
		location = new Vector3(x * width, y * length, 100);
		mapX = x;
		mapY = y;

		//floor = GameObject.CreatePrimitive(PrimitiveType.Cube);

		//floorScale = floor.transform.localScale;

		//floorScale.x = width;
		//floorScale.y = length;

		//floor.transform.position = location;
		//floor.transform.localScale = floorScale;
		floor = (GameObject) GameObject.Instantiate(floorPre, location, Quaternion.identity);


		GameObject daGM = GameObject.FindGameObjectWithTag("GM");
		GameManager GMInfo = daGM.GetComponent<GameManager>();

		GMInfo.spawnDaCreep(location.x, location.y);

	}

	void Update () 
	{
	
	}
}
