using UnityEngine;
using System.Collections;

public class CreditsScript : MonoBehaviour {
	public Texture exit;

	void OnGUI()
	{
		float centerX = Screen.width / 2;
		float centerY = Screen.height / 2;

		Rect exitRect = new Rect(centerX - (exit.width/2), Screen.height - exit.height - 20, exit.width, exit.height);
		if (GUI.Button (exitRect, exit, GUIStyle.none)) {
			Application.LoadLevel (0);
		}
	}
}
