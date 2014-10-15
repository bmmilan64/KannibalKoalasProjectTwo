using UnityEngine;
using System.Collections;

public class Insulter : Enemy {
	public bool daInsulted;
	float insultTimer;
	// Use this for initialization
	void Start () {
		isInsulter = true;
		insultTimer = 0;
		//beaten = false;
	}

	public override void shootInsults(){
		if(insultTimer > 1.0f){
			GameObject daLeader = GameObject.FindGameObjectWithTag("PlayerTag");

			insultTimer = 0;
		}
		else{
			insultTimer = insultTimer + Time.deltaTime;
		}
	}

	// Update is called once per frame
	void Update () {
		randMovement();
		//beenBeaten();
	}
}
