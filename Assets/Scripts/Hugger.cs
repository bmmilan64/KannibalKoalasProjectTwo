using UnityEngine;
using System.Collections;

public class Hugger : Enemy {
	public bool daHug;
	// Use this for initialization
	void Start () {
		siHugger = true;
		//beaten = false;
	}

	public override void Hugging(){

	}
	
	// Update is called once per frame
	void Update () {
		randMovement();
		//beenBeaten();
	}
}
