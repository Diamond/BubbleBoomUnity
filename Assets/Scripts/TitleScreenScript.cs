using UnityEngine;
using System.Collections;

public class TitleScreenScript : MonoBehaviour {
	public Texture newGame;
	public Texture continueGame;
	public Texture endless;
	public Texture credits;
	public Texture options;
	public GUIText topScoreDisplay;

	private int _soundState;

	void Start()
	{
		UpdateDisplay();
		if (PlayerPrefs.HasKey("SoundOn")) {
			_soundState = PlayerPrefs.GetInt ("SoundOn");
		}

		if (PlayerPrefs.HasKey("MusicOn")) {
			if (PlayerPrefs.GetInt("MusicOn") == 0) {
				this.audio.mute = true;
			}
		}
	}

	bool IsSoundOn()
	{
		return _soundState == 1;
	}

	void UpdateDisplay()
	{
		int topScore = 0;
		int topLevel = 0;
		if (PlayerPrefs.HasKey ("TopScore")) {
			topScore = PlayerPrefs.GetInt ("TopScore");
		}
		if (PlayerPrefs.HasKey ("TopLevel")) {
			topLevel = PlayerPrefs.GetInt ("TopLevel");
		}
		topScoreDisplay.text = "Top Score: " + topScore.ToString () + " Top Level: " + topLevel.ToString();
	}

	void OnGUI()
	{
		float centerX = Screen.width / 2;
		float centerY = Screen.height / 2;

		Rect newGameRect = new Rect(centerX - (newGame.width/2), centerY - 50, newGame.width, newGame.height);
		if (GUI.Button (newGameRect, newGame, GUIStyle.none)) {
			PlayerPrefs.SetString ("Mode", "Normal");
			PlayerPrefs.SetInt ("TotalScore", 0);
			PlayerPrefs.SetInt ("Level", 0);
			PlayerPrefs.Save ();
			Application.LoadLevel (1);
		}

		Rect continueGameRect = new Rect(centerX - (continueGame.width/2), centerY + 25, continueGame.width, continueGame.height);
		if (GUI.Button (continueGameRect, continueGame, GUIStyle.none)) {
			PlayerPrefs.SetString ("Mode", "Normal");
			Application.LoadLevel (1);
		}

		Rect endlessRect = new Rect(centerX - (endless.width/2), centerY + 100, endless.width, endless.height);
		if (GUI.Button (endlessRect, endless, GUIStyle.none)) {
			PlayerPrefs.SetString ("Mode", "Endless");
			PlayerPrefs.Save ();
			Application.LoadLevel (1);
		}

		Rect optionsRect = new Rect(centerX - (options.width/2), centerY + 175, options.width, options.height);
		if (GUI.Button (optionsRect, options, GUIStyle.none)) {
			Application.LoadLevel (4);
		}

		Rect creditsRect = new Rect(centerX - (credits.width/2), centerY + 250, credits.width, credits.height);
		if (GUI.Button (creditsRect, credits, GUIStyle.none)) {
			Application.LoadLevel (3);
		}

	}
}
