using UnityEngine;
using System.Collections;

public class PlayerScript : Character {
	/*
	//movement
	private bool moveLeft;
	private bool moveRight;
	private bool moveUp;
	private bool moveDown;
	*/
	private bool wDown;
	private bool aDown;
	private bool sDown;
	private bool dDown;
	//Attributes
	//pos
	public int levelJoke;
	public int levelHug;  
	//neg
	public int levelEvileye;

	
	// Use this for initialization
	void Start () {
		/*
		//controls
		moveLeft = false;
		moveRight = false;
		moveUp = false;
		moveDown = false;
		*/
		wDown = false;
		aDown = false;
		sDown = false;
		dDown = false;
		//attribute setup
		levelJoke = 1;
		levelHug = 1;
		levelEvileye = 1;
		hp  =100;
		
	}

	public void sadden(){

	}

	// Update is called once per frame
	void Update () {
		/*For some reason it only moves once per click..... ><
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
		if (Input.GetKeyDown (KeyCode.W))
		{
			wDown = true;
		}
		if (Input.GetKeyDown (KeyCode.S))
		{
			sDown = true;
		}
		if(Input.GetKeyDown (KeyCode.A))
		{
			aDown = true;
		}
		if(Input.GetKeyDown ( KeyCode.D))
		{
			dDown = true;
		}
		if(Input.GetKeyUp(KeyCode.W))
		{
			wDown = false;
			
		}
		if(Input.GetKeyUp(KeyCode.S))
		{
			sDown = false;
			
		}
		if(Input.GetKeyUp(KeyCode.A))
		{
			aDown = false;
			
		}
		if(Input.GetKeyUp(KeyCode.D))
		{
			dDown = false;
			
		}
		
		if(wDown == true){
			move ("up");
		}
		if(aDown == true){
			move ("left");
		}
		if(sDown == true){
			move ("down");
		}
		if(dDown == true){
			move ("right");
		}
		// 5 - Shooting
		bool shoot = Input.GetButtonDown("Fire1");
		shoot |= Input.GetButtonDown("Fire2");
		// Careful: For Mac users, ctrl + arrow is a bad idea
		
		if (shoot)
		{
			WeaponScript weapon = GetComponent<WeaponScript>();
			if (weapon != null)
			{
				// false because the player is not an enemy
				weapon.Attack(false);
			}
		}
	}
	public void LoseHP(int val){
		this.hp -= val;
	}

	void FixedUpdate()
	{
		// 5 - Move the game object
		//rigidbody2D.velocity = movement;
	}

	void OnDestroy()
	{
		// Game Over.
		// Add the script to the parent because the current game
		// object is likely going to be destroyed immediately.
		transform.parent.gameObject.AddComponent<GameOverScript>();
	}
}
