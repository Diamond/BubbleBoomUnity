using UnityEngine;
using System.Collections;

public class TitleScreenScript : MonoBehaviour {
	public Texture newGame;
	public Texture continueGame;
	public Texture endless;

	void OnGUI()
	{
		if (GUI.Button (new Rect (115, 350, 250, 49), newGame, GUIStyle.none)) {
			Application.LoadLevel (1);
		}

		if (GUI.Button (new Rect (115, 415, 250, 49), continueGame, GUIStyle.none)) {
			print ("you clicked the icon");
		}

		if (GUI.Button (new Rect (115, 480, 250, 49), endless, GUIStyle.none)) {
			print ("you clicked the icon");
		}
	}
}
