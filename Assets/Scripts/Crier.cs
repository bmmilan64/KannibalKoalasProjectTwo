using UnityEngine;
using System.Collections;

public class Crier : Enemy {
	public bool daCry;
	private float cryTimer;
	// Use this for initialization
	void Start () {
		isCrier = true;
		cryTimer =0;
		//beaten = false;
	}

	public override bool Cry(){
		bool takeTears= false;

		if(cryTimer>1){
			takeTears = true;
			cryTimer = 0;
		}
		else{
			cryTimer=  cryTimer + Time.deltaTime;
			takeTears = false;
		}
		return takeTears;
	}

	// Update is called once per frame
	void Update () {
		randMovement();
		Cry();
		//beenBeaten();
	}
}
