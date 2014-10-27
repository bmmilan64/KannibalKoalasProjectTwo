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
	public bool wDown;
	public bool aDown;
	public bool sDown;
	public bool dDown;
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

	public int directionS=3;

	public Sprite perUp;
	public Sprite perDown;
	public Sprite perLeft;
	public Sprite perRight;

	public Sprite ssUp;
	public Sprite ssDown;
	public Sprite ssLeft;
	public Sprite ssRight;

	public Sprite ggUp;
	public Sprite ggDown;
	public Sprite ggLeft;
	public Sprite ggRight;

	public Sprite hhUp;
	public Sprite hhDown;
	public Sprite hhLeft;
	public Sprite hhRight;

	public Sprite hsUp;
	public Sprite hsDown;
	public Sprite hsLeft;
	public Sprite hsRight;

	public Sprite ghUp;
	public Sprite ghDown;
	public Sprite ghLeft;
	public Sprite ghRight;

	public Sprite sgUp;
	public Sprite sgDown;
	public Sprite sgLeft;
	public Sprite sgRight;

	public Sprite allUp;
	public Sprite allDown;
	public Sprite allLeft;
	public Sprite allRight;

	private SpriteRenderer spriteMaker;

	
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
		spriteMaker = GetComponent<SpriteRenderer>();
		if (spriteMaker.sprite == null){

			spriteMaker.sprite = perDown;
		}
		
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
		if(wDown == true){move ("up");directionS = 0; }
		if(aDown == true){move ("left"); directionS = 1; }
		if(sDown == true){move ("down"); directionS = 2; }
		if(dDown == true){move ("right"); directionS = 3; }


		//end of movement

		//new shoot
		if (Input.GetKeyDown (KeyCode.G)){spaceDown = true;canShoot = true;}
		if(Input.GetKeyUp(KeyCode.G)){spaceDown = false;canShoot = false;}

		if(canShoot == true){
			canShoot = false;
			Vector3 shotPos = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z);
			GameObject daShot = (GameObject) GameObject.Instantiate(shotPre, shotPos, Quaternion.identity);
		}
		changeDaSprite();

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
		GUI.Box(new Rect(10, 10, 500, 50),"Health: " +this.hp + " /" + maxHealth + "        Glare Level: " + levelEvileye + "  Hug Level: " + levelHug + "  Joke Level: " + levelJoke);
	}

	void changeDaSprite(){
		//up

		if(directionS == 0){
			spriteMaker.sprite = perUp;
			if(levelJoke >4){
				spriteMaker.sprite = ggUp;
			}
			if(levelHug > 4){
				spriteMaker.sprite = ssUp;
			}
			if(levelEvileye > 4){
				spriteMaker.sprite = hhUp;
			}
			if(levelHug > 4 && levelJoke > 4){
				spriteMaker.sprite = sgUp;
			}
			if(levelHug > 4 && levelEvileye >4){
				spriteMaker.sprite = hsUp;
			}
			if(levelEvileye > 4 && levelJoke > 4){
				spriteMaker.sprite = ghUp;
			}
			if(levelHug > 4 && levelJoke > 4 && levelEvileye > 4){
				spriteMaker.sprite = allUp;
			}
		}

		//left
		if(directionS == 1){
			spriteMaker.sprite = perLeft;
			if(levelJoke >4){
				spriteMaker.sprite = ggLeft;
			}
			if(levelHug > 4){
				spriteMaker.sprite = ssLeft;
			}
			if(levelEvileye > 4){
				spriteMaker.sprite = hhLeft;
			}
			if(levelHug > 4 && levelJoke > 4){
				spriteMaker.sprite = sgLeft;
			}
			if(levelHug > 4 && levelEvileye >4){
				spriteMaker.sprite = hsLeft;
			}
			if(levelEvileye > 4 && levelJoke > 4){
				spriteMaker.sprite = ghLeft;
			}
			if(levelHug > 4 && levelJoke > 4 && levelEvileye > 4){
				spriteMaker.sprite = allLeft;
			}
		}

		//down
		if(directionS == 2){
			spriteMaker.sprite = perDown;
			if(levelJoke >4){
				spriteMaker.sprite = ggDown;
			}
			if(levelHug > 4){
				spriteMaker.sprite = ssDown;
			}
			if(levelEvileye > 4){
				spriteMaker.sprite = hhDown;
			}
			if(levelHug > 4 && levelJoke > 4){
				spriteMaker.sprite = sgDown;
			}
			if(levelHug > 4 && levelEvileye >4){
				spriteMaker.sprite = hsDown;
			}
			if(levelEvileye > 4 && levelJoke > 4){
				spriteMaker.sprite = ghDown;
			}
			if(levelHug > 4 && levelJoke > 4 && levelEvileye > 4){
				spriteMaker.sprite =  allDown;
			}
		}

		//right
		if(directionS == 3){
			spriteMaker.sprite = perRight;
			if(levelJoke >4){
				spriteMaker.sprite = ggRight;
			}
			if(levelHug > 4){
				spriteMaker.sprite = ssRight;
			}
			if(levelEvileye > 4){
				spriteMaker.sprite = hhRight;
			}
			if(levelHug > 4 && levelJoke > 4){
				spriteMaker.sprite = sgRight;
			}
			if(levelHug > 4 && levelEvileye >4){
				spriteMaker.sprite = hsRight;
			}
			if(levelEvileye > 4 && levelJoke > 4){
				spriteMaker.sprite = ghRight;
			}
			if(levelHug > 4 && levelJoke > 4 && levelEvileye > 4){
				spriteMaker.sprite = allRight;
			}
		}

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
