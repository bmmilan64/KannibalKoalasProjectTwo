using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class Crier : Enemy {
	public bool daCry;
	private float cryTimer;

	public Sprite cryUp;
	public Sprite cryDown;
	public Sprite cryLeft;
	public Sprite cryRight;
	private SpriteRenderer spriteMaker;


	// Use this for initialization
	void Start () {
		isCrier = true;
		cryTimer =0;
		//beaten = false;
		spriteMaker = GetComponent<SpriteRenderer>();
		if (spriteMaker.sprite == null)
			spriteMaker.sprite = cryDown;

	}

	public override void Cry(){
		GameObject daPlayer = GameObject.FindGameObjectWithTag("PlayerTag");
		PlayerScript playerInfo = daPlayer.GetComponent<PlayerScript>();

		if((Mathf.Abs (this.transform.position.y) - Mathf.Abs ( daPlayer.transform.position.y) <= 3.0f && 
		    Mathf.Abs (this.transform.position.y) - Mathf.Abs ( daPlayer.transform.position.y) >= -3.0f) && 
		   (Mathf.Abs (this.transform.position.x) - Mathf.Abs ( daPlayer.transform.position.x) <= 3.0f && 
		 Mathf.Abs (this.transform.position.x) - Mathf.Abs ( daPlayer.transform.position.x) >= -3.0f))
		{

			//*****************
			if(cryTimer > 50){
				
				playerInfo.hp--;
				cryTimer = 0;
			}
			else{
				cryTimer++;
			}
		}

	}
	public void changeSprite()
	{
		if( Direction == 0){
			spriteMaker.sprite = cryUp;
		}
		if( Direction == 1)
		{
			spriteMaker.sprite = cryLeft;
		}
		if( Direction == 2)
		{
			spriteMaker.sprite = cryDown;
		}
		if( Direction == 3)
		{
			spriteMaker.sprite = cryRight;
		}
	}

	// Update is called once per frame
	void Update () {
		randMovement();
		Cry();
		changeSprite();
	}
}
