//for the playTime

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour {
	
	//objs
	public GameObject daLeader;
	public List<GameObject> enemies;
	public List<GameObject> itemList;
	
	//prefabs
	//public GameObject LeaderPre;
	
	public GameObject EnemyPre;//generic person that does nothing
	public GameObject CrierPre;
	public GameObject HuggerPre;
	public GameObject InsulterPre;
	
	//public GameObject daCameraPre;
	
	public GameObject ItemPre;
	//counters
	public int numEnemies;
	
	//misc
	private float randomNumber;
	public GameObject daCamera;
	
	// Use this for initialization
	void Start () {
		//values
		numEnemies = 5;
		
		
		//leader
		//Vector3 leaderPos = new Vector3 (-12.0f,-3.0f,1.0f);
		//daLeader = (GameObject) GameObject.Instantiate(LeaderPre, leaderPos, Quaternion.identity);
		daLeader = GameObject.FindGameObjectWithTag("PlayerTag");
		//enemies
		for(int i = 0; i<numEnemies; i++){
			Vector3 enemyPos = new Vector3(Random.Range(0.0f,12.0f),Random.Range(0.0f,5.0f),0.0f);
			randomNumber = Random.Range(0,3);
			GameObject en;
			//picks type of enemy
			if(randomNumber >= 0.0f && randomNumber < 1.0f){
				en = (GameObject) GameObject.Instantiate(InsulterPre, enemyPos, Quaternion.identity);
			}
			else if(randomNumber >= 1.0f && randomNumber < 2.0f){
				en = (GameObject) GameObject.Instantiate(HuggerPre, enemyPos, Quaternion.identity);
			}
			else if(randomNumber >= 2.0f && randomNumber < 3.0f){
				en = (GameObject) GameObject.Instantiate(CrierPre, enemyPos, Quaternion.identity);
			}
			else{
				en = (GameObject) GameObject.Instantiate(EnemyPre, enemyPos, Quaternion.identity);
			}
			enemies.Add(en);
		}
		
		for(int i = 0; i< numEnemies; i++){
			GameObject it;
			Vector3 itLoc = new Vector3( enemies[i].transform.position.x, enemies[i].transform.position.y, enemies[i].transform.position.z );
			it = (GameObject) GameObject.Instantiate(ItemPre, itLoc, Quaternion.identity);
			
			itemList.Add(it);
		}
		
		//camera
		//Vector3 camPos = new Vector3 (-12.0f,-3.0f,-10.0f);
		
		//daCamera = (GameObject) GameObject.Instantiate(daCameraPre, camPos, Quaternion.identity);
		
		
		
	}
	
	// Update is called once per frame
	void Update () {
		for(int i = 0; i<numEnemies; i++){
			//check if y values are close
			if(Mathf.Abs (enemies[i].transform.position.y) - Mathf.Abs ( daLeader.transform.position.y) <=2.0f && 
			   Mathf.Abs (enemies[i].transform.position.y) - Mathf.Abs ( daLeader.transform.position.y) >= -2.0f ){
				//checks the x values are close
				if(Mathf.Abs (enemies[i].transform.position.x) - Mathf.Abs ( daLeader.transform.position.x) <=2.0f && 
				   Mathf.Abs (enemies[i].transform.position.x) - Mathf.Abs ( daLeader.transform.position.x) >= -2.0f ){
					//	if close and 'press x to hug'
					if (Input.GetKeyDown (KeyCode.X))
					{
						//enemies[i].renderer.material.color = Color.red;
						//enemies[i].transform.scale.x = 0.25f;
					}
				}
			}
		}
		
		
	}
}
