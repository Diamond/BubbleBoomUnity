using UnityEngine;
using System.Collections;

public class PausedScript : MonoBehaviour {
	public Texture toggleOn;
	public Texture toggleOff;
	public Texture musicTexture;
	public Texture soundTexture;
	public Texture pausedTexture;
	public Texture exitTexture;

	private Texture _musicToggle;
	private Texture _soundToggle;

	private int _soundState = 1;
	private int _musicState = 1;
	
	void Start()
	{
		if (PlayerPrefs.HasKey("SoundOn")) {
			_soundState = PlayerPrefs.GetInt ("SoundOn");
		}
		if (PlayerPrefs.HasKey("MusicOn")) {
			_musicState = PlayerPrefs.GetInt ("MusicOn");
		}

		if (IsMusicOn ()) {
			_musicToggle = toggleOn;
		} else {
			_musicToggle = toggleOff;
		}
		if (IsSoundOn ()) {
			_soundToggle = toggleOn;
		} else {
			_soundToggle = toggleOff;
		}
	}

	bool IsMusicOn()
	{
		return _musicState == 1;
	}

	bool IsSoundOn()
	{
		return _soundState == 1;
	}

	void ToggleMusic()
	{
		if (_musicToggle == toggleOn) {
			_musicToggle = toggleOff;
			PlayerPrefs.SetInt ("MusicOn", 0);
		} else {
			_musicToggle = toggleOn;
			PlayerPrefs.SetInt ("MusicOn", 1);
		}
		PlayerPrefs.Save();
	}

	void ToggleSound()
	{
		if (_soundToggle == toggleOn) {
			_soundToggle = toggleOff;
			PlayerPrefs.SetInt ("SoundOn", 0);
		} else {
			_soundToggle = toggleOn;
			PlayerPrefs.SetInt ("SoundOn", 1);
		}
		PlayerPrefs.Save();
	}

	void OnGUI()
	{
		float centerX = Screen.width / 2;
		float centerY = Screen.height / 2;

		GUI.DrawTexture(new Rect(centerX - pausedTexture.width / 2, 20, pausedTexture.width, pausedTexture.height), pausedTexture);

		GUI.DrawTexture(new Rect(centerX - musicTexture.width / 2, centerY - 175, musicTexture.width, musicTexture.height), musicTexture);
		Rect musicRect = new Rect(centerX - toggleOn.width / 2, centerY - 100, toggleOn.width, toggleOn.height);
		if (GUI.Button (musicRect, _musicToggle, GUIStyle.none)) {
			ToggleMusic();
		}

		GUI.DrawTexture(new Rect(centerX - soundTexture.width / 2, centerY, soundTexture.width, soundTexture.height), soundTexture);
		Rect soundRect = new Rect(centerX - toggleOn.width / 2, centerY + 75, toggleOn.width, toggleOn.height);
		if (GUI.Button (soundRect, _soundToggle, GUIStyle.none)) {
			ToggleSound();
		}

		Rect exitRect = new Rect(centerX - exitTexture.width / 2, Screen.height - exitTexture.height - 20, exitTexture.width, exitTexture.height);
		if (GUI.Button (exitRect, exitTexture, GUIStyle.none)) {
			Application.LoadLevel(0);
		}
	}
}
