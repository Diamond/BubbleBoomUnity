using UnityEngine;
using System.Collections;

public class TitleScreenScript : MonoBehaviour {
	public Texture newGame;
	public Texture continueGame;
	public Texture endless;

	void OnGUI()
	{
		float centerX = Screen.width / 2;
		float centerY = Screen.height / 2;

		Rect newGameRect = new Rect(centerX - (newGame.width/2), centerY, newGame.width, newGame.height);
		if (GUI.Button (newGameRect, newGame, GUIStyle.none)) {
			PlayerPrefs.SetString ("Mode", "Normal");
			PlayerPrefs.SetInt ("TotalScore", 0);
			PlayerPrefs.SetInt ("Level", 0);
			PlayerPrefs.Save ();
			Application.LoadLevel (1);
		}

		Rect continueGameRect = new Rect(centerX - (continueGame.width/2), centerY + 75, continueGame.width, continueGame.height);
		if (GUI.Button (continueGameRect, continueGame, GUIStyle.none)) {
			PlayerPrefs.SetString ("Mode", "Normal");
			Application.LoadLevel (1);
		}

		Rect endlessRect = new Rect(centerX - (endless.width/2), centerY + 150, endless.width, endless.height);
		if (GUI.Button (endlessRect, endless, GUIStyle.none)) {
			PlayerPrefs.SetString ("Mode", "Endless");
			PlayerPrefs.Save ();
			Application.LoadLevel (1);
		}
	}
}
