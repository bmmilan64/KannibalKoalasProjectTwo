using UnityEngine;
using System.Collections;

public class Items : MonoBehaviour {
	//values
	public float x;
	public float y;
	public float randV;
	public bool Hat;
	public bool Glasses;
	public bool Sweater;

	// Use this for initialization
	void Start () {

		Hat = false;
		Glasses = false;
		Sweater = false;

		randV = Random.Range(0.0f, 3.0f);
		if(randV >= 0.0f && randV <1.0f){
			//this.renderer.material.mainTexture = texturehere;
			Hat = true;
		}
		else if(randV >= 0.0f && randV <1.0f){
			//this.renderer.material.mainTexture = texturehere;
			Glasses = true;
		}
		else if(randV >= 0.0f && randV <1.0f){
			//this.renderer.material.mainTexture = texturehere;
			Sweater = true;
		}
	}



	// Update is called once per frame
	void Update () {
	
	}
}
