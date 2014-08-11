using UnityEngine;
using System.Collections;

public class TransitionScript : MonoBehaviour {
	public Texture nextLevel;
	public Texture exit;
	
	void OnGUI()
	{
		if (GUI.Button (new Rect (100, 300, 310, 49), nextLevel, GUIStyle.none)) {
			Application.LoadLevel (1);
		}
		
		if (GUI.Button (new Rect (190, 415, 122, 49), exit, GUIStyle.none)) {
			Application.LoadLevel (0);
		}
	}
}
