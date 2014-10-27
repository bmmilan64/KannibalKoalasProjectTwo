using UnityEngine;
using System.Collections;

public class InstructionsScript : MonoBehaviour 
{
	void OnGUI()
	{
		// layout in 10ths
		const int instructWidth = 530;
		int bWidth = Screen.width / 10;
		int bHeight = Screen.height / 10;

		// INSTRUCTIONS
		GUI.Box(new Rect((Screen.width / 2) - (bWidth / 2), (1 * Screen.height / 9), bWidth, 25), 
		        "Instructions");

		GUI.Box(new Rect((Screen.width / 2) - (instructWidth / 2), (2 * Screen.height / 9), instructWidth, 230), 
		        "You are part of the Russion Mob.\n" +
		        "\n" +
		        "You have been tasked with infiltrating a school to the respect and\n" +
		        "admiration of the student body in order to hold sway over their minds.\n" +
		        "Use your soft skills to assess and direct their behviors and emotions. \n" +
		        "\n" +
		        "You will encounter weaklings, bullies and friends.\n" +
		        "It is up to you to determine how best to repond, with JOKES(J), HUGS(H), \n" +
		        "or your death GLARE(G).\n" +
		        "Based on your response they might leave you an item that will help you down the road.\n You can pick it up with (E)." +
		        "\n" +
		        "If your reputation drops to zero, you will fail.");

		// START BUTTON
		if (GUI.Button(
			new Rect(Screen.width / 2 - (bWidth / 2), (8 * Screen.height / 10) - (bHeight / 2), bWidth, bHeight),
			"New Game"))
		{
			// On Click, load the level
			Application.LoadLevel("Game"); // scene name
		}
		
		// MENU BUTTON
		if (GUI.Button(
			new Rect(Screen.width / 2 - (bWidth / 2), (9 * Screen.height / 10) - (bHeight / 2), bWidth, bHeight),
			"Menu"))
		{
			// On Click, load the level
			Application.LoadLevel("Menu"); // scene name
		}

		// game title(demo)
		GUI.Label(new Rect(0, 0, Screen.width, Screen.height), "Game Title");
	}
}
