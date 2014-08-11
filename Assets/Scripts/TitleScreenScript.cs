using UnityEngine;
using System.Collections;

public class TitleScreenScript : MonoBehaviour {
	public Texture newGame;
	public Texture continueGame;
	public Texture endless;

	void OnGUI()
	{
		if (GUI.Button (new Rect (115, 350, 250, 49), newGame, GUIStyle.none)) {
			PlayerPrefs.SetInt ("TotalScore", 0);
			PlayerPrefs.SetInt ("Level", 0);
			PlayerPrefs.Save ();
			Application.LoadLevel (1);
		}

		if (GUI.Button (new Rect (115, 415, 250, 49), continueGame, GUIStyle.none)) {
			Application.LoadLevel (1);
		}

		if (GUI.Button (new Rect (115, 480, 250, 49), endless, GUIStyle.none)) {
			print ("Endless Mode is not implemented yet");
		}
	}
}
