using UnityEngine;
using System.Collections;

public class MenuScript : MonoBehaviour {
	
	private GUISkin skin;
	
	void Start()
	{
		// Load a skin for the buttons
		skin = Resources.Load("GUISkin") as GUISkin;
	}
	
	void OnGUI()
	{
		//layour in 10ths
		int bWidth = Screen.width / 10;
		int bHeight = Screen.height / 10;
		
		GUI.skin = skin;
		
		// START BUTTON
		if (GUI.Button(
			new Rect(Screen.width / 2 - (bWidth / 2), (8 * Screen.height / 10) - (bHeight / 2), bWidth, bHeight),
			"New Game"))
		{
			// On Click, load the level
			Application.LoadLevel("Game"); // scene name
		}
		
		// INSTRUCTIONS BUTTON
		if (GUI.Button(
			new Rect(Screen.width / 2 - (bWidth / 2), (9 * Screen.height / 10) - (bHeight / 2), bWidth, bHeight),
			"Instructions"))
		{
			// On Click, load the level
			Application.LoadLevel("Instructions"); // scene name
		}
		
		// game title(demo)
		//GUI.Label(new Rect((Screen.width / 2 - 50), Screen.height / 2, Screen.width, Screen.height), "Game Image Here");
	}
}
