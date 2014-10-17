using UnityEngine;
using System.Collections;

public class Insulter : Enemy {
	public bool daInsulted;
	float insultTimer;
	public GameObject insultPre;
	// Use this for initialization
	void Start () {
		isInsulter = true;
		insultTimer = 0;

		//beaten = false;
	}

	public override void shootInsults(){
		if(insultTimer > 0.75f){
			Vector3 inPos = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z);
			GameObject hurtfulWords = (GameObject) GameObject.Instantiate(insultPre, inPos, Quaternion.identity);
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
		shootInsults();
	}
}
