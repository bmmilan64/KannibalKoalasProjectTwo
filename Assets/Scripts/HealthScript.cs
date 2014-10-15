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
			if(isEnemy == true){
				GameObject it;
				Vector3 itLoc = new Vector3( this.transform.position.x, this.transform.position.y, this.transform.position.z );
				it = (GameObject) GameObject.Instantiate(ItemPre, itLoc, Quaternion.identity);
			}
			// Dead!
			Destroy(gameObject);
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
