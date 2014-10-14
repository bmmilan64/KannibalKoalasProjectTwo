using UnityEngine;
using System.Collections;

public class Crier : Enemy {
	public bool daCry;
	// Use this for initialization
	void Start () {
		daCry = true;
		//beaten = false;
	}
	
	// Update is called once per frame
	void Update () {
		randMovement();
		//beenBeaten();
	}
}
