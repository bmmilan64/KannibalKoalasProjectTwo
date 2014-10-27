using UnityEngine;
using System.Collections;

public class MoveScript : MonoBehaviour {
	
	/// Object speed
	public Vector2 speed = new Vector2(10, 10);

	/// Moving direction
	public Vector2 direction = new Vector2(-1, 1);
	
	private Vector2 movement;

	void Start(){
		GameObject daPlayer = GameObject.FindGameObjectWithTag("PlayerTag");
		PlayerScript playerInfo = daPlayer.GetComponent<PlayerScript>();
		print ("\n directionPlayer " + playerInfo.directionS);
		if(playerInfo.directionS == 0){
			//move.direction = new Vector2(0,1);
			// here
			direction.x = 0;
			direction.y = 1;
		}
		if(playerInfo.directionS == 1){
			direction = new Vector2(-1,0); // here
		}
		if(playerInfo.directionS == 2){
			direction = new Vector2(0,-1); // here
		}
		if(playerInfo.directionS == 3){
			direction = new Vector2(1,0); // here
		}
		
	
	}

	void Update()
	{
		movement = new Vector2(
			speed.x * direction.x,
			speed.y * direction.y);
	}
	
	void FixedUpdate()
	{
		// Apply movement to the rigidbody
		rigidbody2D.velocity = movement;
	}
}
