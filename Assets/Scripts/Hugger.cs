using UnityEngine;
using System.Collections;

public class Hugger : Enemy {
	public bool daHug;
	// Use this for initialization
	void Start () {
		daHug = true;
		//beaten = false;
	}
	
	// Update is called once per frame
	void Update () {
		randMovement();
		//beenBeaten();
	}
}
