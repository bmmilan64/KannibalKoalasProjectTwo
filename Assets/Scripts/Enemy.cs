using UnityEngine;
using System.Collections;

public class Enemy : Character {
	public bool isCrier = false;
	public bool isInsulter = false;
	public bool isHugger = false;

	//Attributes
	float timer;

	//Misc
	private float randVal;
	public bool beaten;
	// Use this for initialization
	void Start () {
		timer = 0.0f;
		randVal = 0.0f;
		beaten = false;
		hp = 10;


	}
	public virtual bool Cry(){return false;}
	public virtual void shootInsults(){}
	public virtual void Hugging(){}

	public void randMovement(){
		//if timer does not work just do random chnaces with high prob of not moving
		//or use a counter ++ to track timer

		//move after certain amount of time
		if(timer >=1.0f){
			randVal = Random.Range(0,4);
			if(randVal >= 0.0f && randVal <1.0f){
				this.transform.position +=  transform.up * 1.0f;
			}
			else if(randVal >= 1.0f && randVal <2.0f){
				this.transform.position +=  transform.right * -1.0f;
			}
			else if(randVal >= 2.0f && randVal <3.0f){
				this.transform.position +=  transform.up * -1.0f;
			}
			else{
				this.transform.position +=  transform.right * 1.0f;
			}

			timer = 0.0f;
		}
		//chill time
		else{
			timer = timer + Time.deltaTime;
		}

	}
	/*
	public void lose(){
		beaten = true;
	}

	public void beenBeaten(){
		if (beaten == true){
			this.renderer.material.color = Color.red; 
		}
	}
	*/
	// Update is called once per frame
	void Update () {
		randMovement();
	}
}
