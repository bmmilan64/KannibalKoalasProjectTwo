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
		Destroy(gameObject, 20); // 20sec
	}
}
