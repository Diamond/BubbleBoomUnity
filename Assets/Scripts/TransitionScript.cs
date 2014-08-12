using UnityEngine;
using System.Collections;

public class TransitionScript : MonoBehaviour {
	public Texture nextLevel;
	public Texture exit;
	public Texture retry;
	private int _currentScore = 0;
	public GUIText scoreDisplay;
	public GUIText successMessage;

	void Start()
	{
		if (PlayerPrefs.HasKey ("TotalScore")) {
			_currentScore = PlayerPrefs.GetInt ("TotalScore");
			scoreDisplay.text = "Current Score: " + _currentScore.ToString();
		}
		if (PlayerPrefs.HasKey ("Status")) {
			successMessage.text = PlayerPrefs.GetString("Status");
		}
	}
	
	void OnGUI()
	{
		float centerX = Screen.width / 2;
		float centerY = Screen.height / 2;

		if (successMessage.text == "Success!") {
			Rect nextLevelRect = new Rect(centerX - (nextLevel.width/2), centerY, nextLevel.width, nextLevel.height);
			if (GUI.Button (nextLevelRect, nextLevel, GUIStyle.none)) {
				Application.LoadLevel (1);
			}
		} else {
			Rect retryRect = new Rect(centerX - (retry.width/2), centerY, retry.width, retry.height);
			if (GUI.Button (retryRect, retry, GUIStyle.none)) {
				Application.LoadLevel (1);
			}
		}

		Rect exitRect = new Rect(centerX - (exit.width/2), centerY + 75, exit.width, exit.height);
		if (GUI.Button (exitRect, exit, GUIStyle.none)) {
			Application.LoadLevel (0);
		}
	}
}
