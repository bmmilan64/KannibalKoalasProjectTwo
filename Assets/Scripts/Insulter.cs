using UnityEngine;
using System.Collections;

public class Insulter : Enemy {
	public bool daInsulted;
	// Use this for initialization
	void Start () {
		daInsulted = true;
		//beaten = false;
	}
	
	// Update is called once per frame
	void Update () {
		randMovement();
		//beenBeaten();
	}
}
