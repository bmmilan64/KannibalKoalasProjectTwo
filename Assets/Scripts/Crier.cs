using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class Crier : Enemy {
	public bool daCry;
	private float cryTimer;



	// Use this for initialization
	void Start () {
		isCrier = true;
		cryTimer =0;
		//beaten = false;
	}

	public override void Cry(){
		GameObject daPlayer = GameObject.FindGameObjectWithTag("PlayerTag");
		PlayerScript playerInfo = daPlayer.GetComponent<PlayerScript>();

		if((Mathf.Abs (this.transform.position.y) - Mathf.Abs ( daPlayer.transform.position.y) <= 4.0f && 
		    Mathf.Abs (this.transform.position.y) - Mathf.Abs ( daPlayer.transform.position.y) >= -4.0f) && 
		   (Mathf.Abs (this.transform.position.x) - Mathf.Abs ( daPlayer.transform.position.x) <= 4.0f && 
		 Mathf.Abs (this.transform.position.x) - Mathf.Abs ( daPlayer.transform.position.x) >= -4.0f))
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

	// Update is called once per frame
	void Update () {
		randMovement();
		//Cry();

	}
}
