//for the playTime

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour {
	
	//objs
	public GameObject daLeader;
	public List<GameObject> enemies;
	public List<GameObject> itemList;
	public int enemyIncr = 0;
	
	//prefabs
	//public GameObject LeaderPre;
	
	public GameObject EnemyPre;//generic person that does nothing
	public GameObject CrierPre;
	public GameObject HuggerPre;
	public GameObject InsulterPre;
	public GameObject hugzPre;
	public GameObject jokePre;
	
	//public GameObject daCameraPre;
	
	public GameObject ItemPre;
	//counters
	public int initNumEnemies = 5;
	
	//misc
	private float randomNumber;
	public GameObject daCamera;
	
	// Use this for initialization
	void Start () 
	{
		//leader
		daLeader = GameObject.FindGameObjectWithTag("PlayerTag");
		//enemies
		for(int i = 0; i<initNumEnemies; i++){
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


	}

	public void spawnDaCreep(float daX, float daY){
		for(int i = 0; i<initNumEnemies + enemyIncr; i++){
			Vector3 enemyPos = new Vector3(Random.Range(0.0f,12.0f)+daX,Random.Range(0.0f,5.0f)+daY,0.0f);
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
	}
	
	// Update is called once per frame
	void Update () 
	{
		var thePlayer = daLeader;
		PlayerScript playerInfo = thePlayer.GetComponent<PlayerScript>();
		if (Input.GetKeyDown (KeyCode.E)){
			print("Clicked " + itemList.Count);
		for (int p = 0; p< itemList.Count; p++){
			if((Mathf.Abs (itemList[p].transform.position.y) - Mathf.Abs ( daLeader.transform.position.y) <= 2.5f && 
			    Mathf.Abs (itemList[p].transform.position.y) - Mathf.Abs ( daLeader.transform.position.y) >= -2.5f) && 
			    Mathf.Abs (itemList[p].transform.position.x) - Mathf.Abs ( daLeader.transform.position.x) <= 2.5f && 
			    Mathf.Abs (itemList[p].transform.position.x) - Mathf.Abs ( daLeader.transform.position.x) >= -2.5f){



					GameObject tbdItem = itemList[p];
					itemList.Remove (itemList[p]);

					int randLvl = Random.Range(0,3);
					if(randLvl >=0 && randLvl <1){
						playerInfo.levelJoke++;
					}
					else if(randLvl >=1 && randLvl <2){
						playerInfo.levelHug++;
					}
					else{
						playerInfo.levelEvileye++;
					}

					Destroy(tbdItem);
				}
			}
		}
		for(int i = 0; i < enemies.Count; i++)
		{
			var evilPerson = enemies[i];
			Enemy evilInfo = evilPerson.GetComponent<Enemy>();

			//for joke or hug
			if((Mathf.Abs (enemies[i].transform.position.y) - Mathf.Abs ( daLeader.transform.position.y) <= 2.5f && 
			    Mathf.Abs (enemies[i].transform.position.y) - Mathf.Abs ( daLeader.transform.position.y) >= -2.5f) && 
			    Mathf.Abs (enemies[i].transform.position.x) - Mathf.Abs ( daLeader.transform.position.x) <= 2.5f && 
			    Mathf.Abs (enemies[i].transform.position.x) - Mathf.Abs ( daLeader.transform.position.x) >= -2.5f){
				//for insulter
				if(evilInfo.isInsulter == true)
				{
					if (Input.GetKeyDown (KeyCode.H))
					{
						Vector3 hugzPos = new Vector3(daLeader.transform.position.x, daLeader.transform.position.y + 0.5f, 0.0f);
						GameObject daHugz = (GameObject) GameObject.Instantiate(hugzPre,hugzPos , Quaternion.identity);


						GameObject tbd = enemies[i];
						enemies.Remove(enemies[i]);

						//killed enemy wrong
						playerInfo.hp -= 5;

						//spawns item
						GameObject it;
						Vector3 itLoc = new Vector3( tbd.transform.position.x, tbd.transform.position.y, tbd.transform.position.z );
						//it = (GameObject) GameObject.Instantiate(ItemPre, itLoc, Quaternion.identity);//spawns two items for some reason...~John
						//itemList.Add(it);
						Destroy(tbd);
						break;
					}
					else if (Input.GetKeyDown (KeyCode.J))
					{

						Vector3 JokePos = new Vector3(daLeader.transform.position.x, daLeader.transform.position.y + 0.5f, 0.0f);
						GameObject daJoke = (GameObject) GameObject.Instantiate(jokePre,JokePos , Quaternion.identity);

						GameObject tbd = enemies[i];
						enemies.Remove(enemies[i]);
						
						//killed enemy wrong
						playerInfo.hp -= 5;
						
						//spawns item
						GameObject it;
						Vector3 itLoc = new Vector3( tbd.transform.position.x, tbd.transform.position.y, tbd.transform.position.z );
						//it = (GameObject) GameObject.Instantiate(ItemPre, itLoc, Quaternion.identity);//spawns two items for some reason...~John
						//itemList.Add(it);
						Destroy(tbd);
						break;
					}
					
				}
				//for hugger
				if(evilInfo.isHugger == true)
				{
					if (Input.GetKeyDown (KeyCode.H))
					{
						Vector3 hugzPos = new Vector3(daLeader.transform.position.x, daLeader.transform.position.y + 0.5f, 0.0f);
						GameObject daHugz = (GameObject) GameObject.Instantiate(hugzPre,hugzPos , Quaternion.identity);
						GameObject tbd = enemies[i];
						enemies.Remove(enemies[i]);
						

						playerInfo.hp += (2 + playerInfo.levelHug);
						
						//spawns item
						GameObject it;
						Vector3 itLoc = new Vector3( tbd.transform.position.x, tbd.transform.position.y, tbd.transform.position.z );
						it = (GameObject) GameObject.Instantiate(ItemPre, itLoc, Quaternion.identity);//spawns two items for some reason...~John
						itemList.Add(it);
						Destroy(tbd);
						break;
					}
					else if (Input.GetKeyDown (KeyCode.J))
					{
						Vector3 JokePos = new Vector3(daLeader.transform.position.x, daLeader.transform.position.y + 0.5f, 0.0f);
						GameObject daJoke = (GameObject) GameObject.Instantiate(jokePre,JokePos , Quaternion.identity);
						GameObject tbd = enemies[i];
						enemies.Remove(enemies[i]);
						
						//killed enemy wrong
						playerInfo.hp -= 5;
						
						//spawns item
						GameObject it;
						Vector3 itLoc = new Vector3( tbd.transform.position.x, tbd.transform.position.y, tbd.transform.position.z );
						//it = (GameObject) GameObject.Instantiate(ItemPre, itLoc, Quaternion.identity);//spawns two items for some reason...~John
						//itemList.Add(it);
						Destroy(tbd);
						break;
					}
				}
				//for crier
				if(evilInfo.isCrier == true)
				{
					if (Input.GetKeyDown (KeyCode.H))
					{
						Vector3 hugzPos = new Vector3(daLeader.transform.position.x, daLeader.transform.position.y + 0.5f, 0.0f);
						GameObject daHugz = (GameObject) GameObject.Instantiate(hugzPre,hugzPos , Quaternion.identity);
						GameObject tbd = enemies[i];
						enemies.Remove(enemies[i]);
						
						//killed enemy wrong
						playerInfo.hp -= 5;
						
						//spawns item
						GameObject it;
						Vector3 itLoc = new Vector3( tbd.transform.position.x, tbd.transform.position.y, tbd.transform.position.z );
						//it = (GameObject) GameObject.Instantiate(ItemPre, itLoc, Quaternion.identity);//spawns two items for some reason...~John
						//itemList.Add(it);
						Destroy(tbd);
						break;
					}
					else if (Input.GetKeyDown (KeyCode.J))
					{
						Vector3 JokePos = new Vector3(daLeader.transform.position.x, daLeader.transform.position.y + 0.5f, 0.0f);
						GameObject daJoke = (GameObject) GameObject.Instantiate(jokePre,JokePos , Quaternion.identity);
						GameObject tbd = enemies[i];
						enemies.Remove(enemies[i]);
						

						playerInfo.hp += (2 + playerInfo.levelJoke);
						
						//spawns item
						GameObject it;
						Vector3 itLoc = new Vector3( tbd.transform.position.x, tbd.transform.position.y, tbd.transform.position.z );
						it = (GameObject) GameObject.Instantiate(ItemPre, itLoc, Quaternion.identity);//spawns two items for some reason...~John
						itemList.Add(it);
						Destroy(tbd);
						break;
					}
				}
			}


		}
		//resets people so game doesnt end yet (not boring)
		if(enemies.Count <=0){//make a function later that does this
			enemyIncr += 3;
			spawnDaCreep(playerInfo.transform.position.x,playerInfo.transform.position.y);
		}
		if(playerInfo.hp >100){
			playerInfo.hp = 100;
		}
		if(playerInfo.hp <1){
			//gg
			Application.LoadLevel ("GameOver");
		}
	}//end of update

}
