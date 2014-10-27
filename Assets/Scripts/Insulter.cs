using UnityEngine;
using System.Collections;

public class Insulter : Enemy {
	public bool daInsulted;
	float insultTimer;
	public GameObject insultPre;

	public Sprite insulterUp;
	public Sprite insulterDown;
	public Sprite insulterLeft;
	public Sprite insulterRight;
	private SpriteRenderer spriteMaker;

	// Use this for initialization
	void Start () {
		isInsulter = true;
		insultTimer = 0;

		spriteMaker = GetComponent<SpriteRenderer>();
		if (spriteMaker.sprite == null)
			spriteMaker.sprite = insulterDown;
		//beaten = false;
	}

	public override void shootInsults(){
		GameObject daPlayer = GameObject.FindGameObjectWithTag("PlayerTag");
		PlayerScript playerInfo = daPlayer.GetComponent<PlayerScript>();
		if(insultTimer > 0.75f){
			float spawnA = 0.0f;
			if(this.transform.position.x < playerInfo.transform.position.x){
				spawnA = 1.0f;
			}
			if(this.transform.position.x > playerInfo.transform.position.x){
				spawnA = -1.0f;
			}
			Vector3 inPos = new Vector3(this.transform.position.x + spawnA, this.transform.position.y, this.transform.position.z);
			GameObject hurtfulWords = (GameObject) GameObject.Instantiate(insultPre, inPos, Quaternion.identity);
			insultTimer = 0;
		}
		else{
			insultTimer = insultTimer + Time.deltaTime;
		}
	}
	public void changeSprite()
	{
		if( Direction == 0)
			spriteMaker.sprite = insulterUp;
		
		if( Direction == 1)
			spriteMaker.sprite = insulterLeft;
		
		if( Direction == 2)
			spriteMaker.sprite = insulterDown;
		
		if( Direction == 3)
			spriteMaker.sprite = insulterRight;
	}

	// Update is called once per frame
	void Update () {
		randMovement();
		//beenBeaten();
		shootInsults();
		changeSprite();
	}
}
