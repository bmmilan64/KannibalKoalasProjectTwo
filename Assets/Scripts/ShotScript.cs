using UnityEngine;
using System.Collections;

public class ShotScript : MonoBehaviour 
{
	/// Damage inflicted
	public int damage = 1;

	/// Projectile damage player or enemies?
	public bool isEnemyShot = false;
	
	void Start()
	{
		// 2 - Limited time to live to avoid any leak
		Destroy(gameObject, 5); // 20sec
	}

	void OnCollisionEnter2D(Collision2D collider)
	{
		print("hit2"); //this one never gets called for some reason

		if(collider.gameObject.name == "wall_horizontal" || collider.gameObject.name == "vertical" || collider.gameObject.name == "wall_vertical")
		{
			Destroy(gameObject);
		}

	}

}
