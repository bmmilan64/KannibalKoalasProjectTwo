using UnityEngine;
using System.Collections;

public class flyingInsult : MonoBehaviour {
	float xDir = 0.0f;
	float yDir = 0.0f;
	Vector2 vecDir;


	// Use this for initialization
	void Start () {
		GameObject daPlayer = GameObject.FindGameObjectWithTag("PlayerTag");
		PlayerScript playerInfo = daPlayer.GetComponent<PlayerScript>();

		float playX = playerInfo.transform.position.x;
		float playY = playerInfo.transform.position.y;

		xDir = playX - this.transform.position.x;
		yDir = playY - this.transform.position.y;

		vecDir.x = xDir;
		vecDir.y = yDir;

		vecDir.Normalize();

		Destroy(gameObject, 1);
	}

	// Update is called once per frame
	void Update () {
		this.transform.position +=  transform.right *  vecDir.x *0.1f;	
		this.transform.position +=  transform.up *  vecDir.y * 0.1f;


	}

	void OnCollisionEnter2D(Collision2D collider)
	{

		print("what hit?");
		if(collider.gameObject.name == "wall_horizontal" || collider.gameObject.name == "vertical" || collider.gameObject.name == "wall_vertical")
		{
			Destroy(gameObject);
			print("hit wall");
		}

		if(collider.gameObject.name == "player")
		{
			Destroy(gameObject);
			GameObject daPlayer = GameObject.FindGameObjectWithTag("PlayerTag");
			PlayerScript playerInfo = daPlayer.GetComponent<PlayerScript>();
			playerInfo.hp -= 5;
			print("hit player");
		}
	}
}
