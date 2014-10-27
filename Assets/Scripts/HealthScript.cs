using UnityEngine;
using System.Collections;

public class HealthScript : MonoBehaviour {
	public GameObject ItemPre;
	/// Total hitpoints
	public int hp = 1;

	/// Enemy or player?
	public bool isEnemy = true;

	/// Inflicts damage and check if the object should be destroyed
	/// <param name="damageCount"></param>
	public void Damage(int damageCount)
	{
		hp -= damageCount;
		
		if (hp <= 0)
		{
			//print(gameObject.name);
			if(gameObject.name == "Crier(Clone)"){

				print ("IM DONE WITH THIS PROJECT");
				GameObject daGM = GameObject.FindGameObjectWithTag("GM");
				GameManager GMInfo = daGM.GetComponent<GameManager>();
				GameObject daPlayer = GameObject.FindGameObjectWithTag("PlayerTag");
				PlayerScript playerInfo = daPlayer.GetComponent<PlayerScript>();

				//change hp for killing wrong way
				playerInfo.hp-=5;

				//gets rid of crier
				GMInfo.enemies.Remove(gameObject);
				Destroy(gameObject);

				//spawns item
				//GameObject it;
				Vector3 itLoc = new Vector3( this.transform.position.x, this.transform.position.y, this.transform.position.z );
				//it = (GameObject) GameObject.Instantiate(ItemPre, itLoc, Quaternion.identity);//spawns two items for some reason...~John

			}
			if(gameObject.name == "Hugger(Clone)"){
				GameObject daGM = GameObject.FindGameObjectWithTag("GM");
				GameManager GMInfo = daGM.GetComponent<GameManager>();
				GameObject daPlayer = GameObject.FindGameObjectWithTag("PlayerTag");
				PlayerScript playerInfo = daPlayer.GetComponent<PlayerScript>();
				
				//change hp for killing wrong way
				playerInfo.hp-=5;
				
				//gets rid of hugger
				GMInfo.enemies.Remove(gameObject);
				Destroy(gameObject);
				
				//spawns item
				GameObject it;
				Vector3 itLoc = new Vector3( this.transform.position.x, this.transform.position.y, this.transform.position.z );
				//it = (GameObject) GameObject.Instantiate(ItemPre, itLoc, Quaternion.identity);//spawns two items for some reason...~John
			}
			if(gameObject.name == "Insulter(Clone)"){
				GameObject daGM = GameObject.FindGameObjectWithTag("GM");
				GameManager GMInfo = daGM.GetComponent<GameManager>();
				GameObject daPlayer = GameObject.FindGameObjectWithTag("PlayerTag");
				PlayerScript playerInfo = daPlayer.GetComponent<PlayerScript>();
				
				//change hp for killing wrong way
				playerInfo.hp+=5;
				
				//gets rid of hugger
				GMInfo.enemies.Remove(gameObject);
				Destroy(gameObject);
				
				//spawns item
				GameObject it;
				Vector3 itLoc = new Vector3( this.transform.position.x, this.transform.position.y, this.transform.position.z );
				it = (GameObject) GameObject.Instantiate(ItemPre, itLoc, Quaternion.identity);//spawns two items for some reason...~John
				GMInfo.itemList.Add(it);
			}
		}
	}
	
	void OnTriggerEnter2D(Collider2D otherCollider)
	{
		// Is this a shot?
		ShotScript shot = otherCollider.gameObject.GetComponent<ShotScript>();
		if (shot != null)
		{
			// Avoid friendly fire
			if (shot.isEnemyShot != isEnemy)
			{
				Damage(shot.damage);

				// Destroy the shot
				Destroy(shot.gameObject); // Remember to always target the game object, otherwise you will just remove the script
			}
		}


	}
}
