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
		Debug.Log("Collide with wall");
		if(collider.gameObject.name == "wall_horizontal" || collider.gameObject.name == "vertical")
		{
			Destroy(gameObject);
		}
	}
}
