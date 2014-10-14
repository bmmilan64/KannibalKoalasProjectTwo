using UnityEngine;
using System.Collections;

public class Leader : Character {

	//movement
	private bool moveLeft;
	private bool moveRight;
	private bool moveUp;
	private bool moveDown;

	//Attributes
		//pos
	public int levelJoke;
	public int levelHug;  
		//neg
	public int levelEvileye;

	// Use this for initialization
	void Start () {
		//controls
		moveLeft = false;
		moveRight = false;
		moveUp = false;
		moveDown = false;
		//attribute setup
		levelJoke = 1;
		levelHug = 1;
		levelEvileye = 1;

	}
	
	// Update is called once per frame
	void Update () {
		/*Only moved one square at a time >< idk why
		//Start of controls
		if (Input.GetKeyDown (KeyCode.W))
		{
			moveUp = true;
			move ("up");
		}
		if (Input.GetKeyDown (KeyCode.S))
		{
			moveDown = true;
			move ("down");
		}
		if(Input.GetKeyDown (KeyCode.A))
		{
			moveLeft = true;
			move ("left");
		}
		if(Input.GetKeyDown ( KeyCode.D))
		{
			moveRight = true;
			move ("right");
		}
		if(Input.GetKeyUp(KeyCode.W)) { moveUp = false; }
		if(Input.GetKeyUp(KeyCode.S)) { moveDown = false; }
		if(Input.GetKeyUp(KeyCode.A)) { moveLeft = false; }
		if(Input.GetKeyUp(KeyCode.D)) { moveRight = false; }
		
		
		//end of controls
		*/
	}
}
