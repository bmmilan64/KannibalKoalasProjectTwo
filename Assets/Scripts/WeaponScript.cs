using UnityEngine;
using System.Collections;

public class WeaponScript : MonoBehaviour {

	public Transform shotPrefab;
	/// Cooldown in seconds between two shots
	public float shootingRate = 0.25f;

	// 2 - Cooldown
	private float shootCooldown;
	
	void Start()
	{
		shootCooldown = 0f;
	}
	
	void Update()
	{
		if (shootCooldown > 0)
		{
			shootCooldown -= Time.deltaTime;
		}
	}

	// 3 - Shooting from another script
	/// Create a new projectile if possible
	public void Attack(bool isEnemy)
	{
		if (CanAttack)
		{
			shootCooldown = shootingRate;
			// Create a new shot
			var shotTransform = Instantiate(shotPrefab) as Transform;
			// Assign position
			shotTransform.position = transform.position;
			
			// The is enemy property
			ShotScript shot = shotTransform.gameObject.GetComponent<ShotScript>();
			if (shot != null)
			{
				shot.isEnemyShot = isEnemy;
			}
			
			// Make the weapon shot always towards it
			MoveScript move = shotTransform.gameObject.GetComponent<MoveScript>();
			/*
			if (move != null)
			{
				GameObject daPlayer = GameObject.FindGameObjectWithTag("PlayerTag");
				PlayerScript playerInfo = daPlayer.GetComponent<PlayerScript>();
				print ("\n directionPlayer " + playerInfo.directionS);
				if(playerInfo.directionS == 0){
					//move.direction = new Vector2(0,1);
					// here
					move.direction.x = 0;
					move.direction.y = 0;
				}
				if(playerInfo.directionS == 1){
					move.direction = new Vector2(-1,0); // here
				}
				if(playerInfo.directionS == 2){
					move.direction = new Vector2(0,-1); // here
				}
				if(playerInfo.directionS == 3){
					move.direction = new Vector2(1,0); // here
				}

			}
			*/
		}
	}

	/// Is the weapon ready to create a new projectile?
	public bool CanAttack
	{
		get
		{
			return shootCooldown <= 0f;
		}
	}
}
