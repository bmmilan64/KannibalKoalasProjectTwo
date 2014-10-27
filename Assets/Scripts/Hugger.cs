using UnityEngine;
using System.Collections;

public class Hugger : Enemy {
	public bool daHug;

	public Sprite hugUp;
	public Sprite hugDown;
	public Sprite hugLeft;
	public Sprite hugRight;
	private SpriteRenderer spriteMaker;
	// Use this for initialization
	void Start () {
		isHugger = true;
		//beaten = false;
		spriteMaker = GetComponent<SpriteRenderer>();
		if (spriteMaker.sprite == null)
			spriteMaker.sprite = hugDown;
	}

	public override void Hugging(){

	}

	public void goHugging(){
		GameObject daPlayer = GameObject.FindGameObjectWithTag("PlayerTag");
		PlayerScript playerInfo = daPlayer.GetComponent<PlayerScript>();

		//player is under
		if(this.transform.position.y > playerInfo.transform.position.y){
			this.transform.position +=  transform.up * -0.08f;
			Direction = 2;
		}
		//player is above
		if(this.transform.position.y < playerInfo.transform.position.y){
			this.transform.position +=  transform.up * 0.08f;
			Direction = 0;
		}
		//player to its right
		if(this.transform.position.x <playerInfo.transform.position.x){
			this.transform.position +=  transform.right * 0.08f;
			Direction = 3;
		}
		//player to its left
		if(this.transform.position.x >playerInfo.transform.position.x){
			this.transform.position +=  transform.right * -0.08f;
			Direction = 1;
		}



	}
	public void changeSprite()
	{
		if( Direction == 0)
			spriteMaker.sprite = hugUp;
		
		if( Direction == 1)
			spriteMaker.sprite = hugLeft;
		
		if( Direction == 2)
			spriteMaker.sprite = hugDown;
		
		if( Direction == 3)
			spriteMaker.sprite = hugRight;
	}


	// Update is called once per frame
	void Update () {
		//randMovement();
		//beenBeaten();
		goHugging();
		changeSprite();
	}
}
