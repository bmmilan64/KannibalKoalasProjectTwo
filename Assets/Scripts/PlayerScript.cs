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
	private bool spaceDown;
	//Attributes
	//pos
	public int levelJoke;
	public int levelHug;  
	//neg
	public int levelEvileye;
	public GameObject shotPre;
	private bool canShoot;

	//health stuff
	private float healthBarLength;
	public int maxHealth = 100;

	
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
		spaceDown = false;
		//attribute setup
		levelJoke = 1;
		levelHug = 1;
		levelEvileye = 1;
		hp  = 100;
		healthBarLength = Screen.height - 20;
		
	}

	// Update is called once per frame
	void Update () {
		//movement
		if (Input.GetKeyDown (KeyCode.W)){wDown = true;}
		if (Input.GetKeyDown (KeyCode.S)){sDown = true;}
		if(Input.GetKeyDown (KeyCode.A)){aDown = true;}
		if(Input.GetKeyDown ( KeyCode.D)){dDown = true;}
		if(Input.GetKeyUp(KeyCode.W)){wDown = false;}
		if(Input.GetKeyUp(KeyCode.S)){sDown = false;}
		if(Input.GetKeyUp(KeyCode.A)){aDown = false;}
		if(Input.GetKeyUp(KeyCode.D)){dDown = false;}
		if(wDown == true){move ("up");}
		if(aDown == true){move ("left");}
		if(sDown == true){move ("down");}
		if(dDown == true){move ("right");}
		//end of movement

		//new shoot
		if (Input.GetKeyDown (KeyCode.Space)){spaceDown = true;canShoot = true;}
		if(Input.GetKeyUp(KeyCode.Space)){spaceDown = false;canShoot = false;}

		if(canShoot == true){
			canShoot = false;
			Vector3 shotPos = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z);
			GameObject daShot = (GameObject) GameObject.Instantiate(shotPre, shotPos, Quaternion.identity);
		}

		/* old shoot
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
		*/
	}//end of update

	void OnGUI () 
	{
		GUI.Box(new Rect(10, 10, 50, healthBarLength), this.hp + " /" + maxHealth);
	}

	void FixedUpdate()
	{
		// 5 - Move the game object
		//rigidbody2D.velocity = movement;
	}
	/*player destroy that i didnt make ~John
	void OnDestroy()
	{
		// Game Over.
		// Add the script to the parent because the current game
		// object is likely going to be destroyed immediately.
		transform.parent.gameObject.AddComponent<GameOverScript>();
	}
	*/
}
