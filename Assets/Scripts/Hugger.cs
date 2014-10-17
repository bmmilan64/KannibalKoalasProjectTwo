using UnityEngine;
using System.Collections;

public class Hugger : Enemy {
	public bool daHug;
	// Use this for initialization
	void Start () {
		isHugger = true;
		//beaten = false;
	}

	public override void Hugging(){

	}

	public void goHugging(){
		GameObject daPlayer = GameObject.FindGameObjectWithTag("PlayerTag");
		PlayerScript playerInfo = daPlayer.GetComponent<PlayerScript>();

		//player to its right
		if(this.transform.position.x <playerInfo.transform.position.x){
			this.transform.position +=  transform.right * 0.08f;
		}
		//player to its left
		if(this.transform.position.x >playerInfo.transform.position.x){
			this.transform.position +=  transform.right * -0.08f;
		}

		//player is under
		if(this.transform.position.y > playerInfo.transform.position.y){
			this.transform.position +=  transform.up * -0.08f;
		}
		//player is above
		if(this.transform.position.y < playerInfo.transform.position.y){
			this.transform.position +=  transform.up * 0.08f;
		}

	}

	// Update is called once per frame
	void Update () {
		//randMovement();
		//beenBeaten();
		goHugging();
	}
}
