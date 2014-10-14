using UnityEngine;
using System.Collections;

public class Character : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

	public void move(string direction){
		if(direction == "up"){
			this.transform.position +=  transform.up * 0.1f;
		}
		if(direction == "left"){
			this.transform.position +=  transform.right * -0.1f;
		}
		
		if(direction == "down"){
			this.transform.position +=  transform.up * -0.1f;
		}
		
		if(direction == "right"){
			this.transform.position +=  transform.right * 0.1f;
		}
	}

	// Update is called once per frame
	void Update () {
	
	}
}
