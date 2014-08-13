using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class GameControlScript : MonoBehaviour {
	public int score = 0;
	public int level = 0;
	public bool ranExplosion = false;
	public Transform bubbleSpawner;
	public Transform explosionSpawner;
	public Transform scoreDisplay;
	public Texture exit;

	private BubbleSpawner _bs;
	private ExplosionSpawner _es;
	private int _nextLevel;
	private int _totalScore = 0;

	private bool endlessMode = false;

	// Use this for initialization
	void Start () {
		RetrieveGameState ();
		_bs = bubbleSpawner.GetComponent<BubbleSpawner> ();
		_es = explosionSpawner.GetComponent<ExplosionSpawner> ();

		ranExplosion = false;
		score = 0;

		if (endlessMode) {
			Reset();
			_bs.SpawnBubbles(20);
			scoreDisplay.guiText.text = "Endless Mode";
		} else {
			TransitionToNextLevel ();
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (_es.transform.childCount > 0) {
			ranExplosion = true;
		}
		if (ranExplosion && _es.transform.childCount == 0) {
			if (endlessMode) {
				Reset();
				_bs.SpawnBubbles(20);
			} else {
				TransitionToNextLevel(true);
			}
		}
	}

	public void UpdateScoreDisplay()
	{
		if (endlessMode) {
			scoreDisplay.guiText.text = "Endless Mode";
		} else {
			scoreDisplay.guiText.text = "Score " + score.ToString () + " / Next " + _nextLevel.ToString();
		}
	}

	public void AddPoint()
	{
		score++;
		UpdateScoreDisplay ();
	}

	public void TransitionToNextLevel(bool andTransition=false)
	{
		Reset ();
		switch (level % 10) {
		case 1:
			_bs.SpawnBubbles (5);
			_nextLevel = 2;
			break;
		case 2:
			_bs.SpawnBubbles (15);
			_nextLevel = 3;
			break;
		case 3:
			_bs.SpawnBubbles (15);
			_nextLevel = 5;
			break;
		case 4:
			_bs.SpawnBubbles (15);
			_nextLevel = 7;
			break;
		case 5:
			_bs.SpawnBubbles (20);
			_nextLevel = 10;
			break;
		case 6:
			_bs.SpawnBubbles (20);
			_nextLevel = 13;
			break;
		case 7:
			_bs.SpawnBubbles (25);
			_nextLevel = 15;
			break;
		case 8:
			_bs.SpawnBubbles (30);
			_nextLevel = 17;
			break;
		case 9:
			_bs.SpawnBubbles (30);
			_nextLevel = 19;
			break;
		case 10:
			_bs.SpawnBubbles(30);
			_nextLevel = 22;
			break;
		case 11:
			_bs.SpawnBubbles(30);
			_nextLevel = 24;
			break;
		case 12:
			_bs.SpawnBubbles(30);
			_nextLevel = 26;
			break;
		case 13:
			_bs.SpawnBubbles(35);
			_nextLevel = 28;
			break;
		case 14:
			_bs.SpawnBubbles(30);
			_nextLevel = 28;
			break;
		case 15:
			_bs.SpawnBubbles(25);
			_nextLevel = 23;
			break;
		case 16:
			_bs.SpawnBubbles(20);
			_nextLevel = 18;
			break;
		case 17:
			_bs.SpawnBubbles(18);
			_nextLevel = 16;
			break;
		case 18:
			_bs.SpawnBubbles(15);
			_nextLevel = 12;
			break;
		case 19:
			_bs.SpawnBubbles(40);
			_nextLevel = 40;
			break;
		default:
		case 0:
			_bs.SpawnBubbles (5);
			_nextLevel = 1;
			break;
		}
		if (score >= _nextLevel) {
			level++;
			_totalScore += score;
			PlayerPrefs.SetString ("Status", "Success!");
		} else {
			PlayerPrefs.SetString ("Status", "Failure!");
		}
		score = 0;
		UpdateScoreDisplay ();
		UpdateGameState ();
		if (andTransition) {
			Application.LoadLevel (2);
		}
	}

	public void Reset()
	{
		var children = new List<GameObject>();
		foreach (Transform child in _bs.transform) children.Add(child.gameObject);
		children.ForEach(child => Destroy(child));
		ranExplosion = false;
	}

	public void UpdateGameState()
	{
		int currentTopScore = 0;
		int currentTopLevel = 0;
		if (PlayerPrefs.HasKey("TopScore")) {
			currentTopScore = PlayerPrefs.GetInt("TopScore");
			if (_totalScore > currentTopScore) {
				PlayerPrefs.SetInt ("TopScore", _totalScore);
			}
		} else {
			PlayerPrefs.SetInt ("TopScore", _totalScore);
		}
		if (PlayerPrefs.HasKey ("TopLevel")) {
			currentTopLevel = PlayerPrefs.GetInt ("TopLevel");
			if (level > currentTopLevel) {
				PlayerPrefs.SetInt("TopLevel", level);
			}
		} else {
			PlayerPrefs.SetInt("TopLevel", level);
		}
		PlayerPrefs.SetInt ("TotalScore", _totalScore);
		PlayerPrefs.SetInt ("Level", level);
		PlayerPrefs.Save ();
	}

	public void RetrieveGameState()
	{
		if (PlayerPrefs.HasKey ("Level")) {
			level = PlayerPrefs.GetInt ("Level");
		}
		if (PlayerPrefs.HasKey ("TotalScore")) {
			_totalScore = PlayerPrefs.GetInt ("TotalScore");
		}
		if (PlayerPrefs.HasKey("Mode")) {
			endlessMode = PlayerPrefs.GetString("Mode") == "Endless";
		}
		score = 0;
	}

	void OnGUI()
	{
		float centerX = Screen.width / 2;
		float centerY = Screen.height / 2;
		Rect exitRect = new Rect(centerX - (exit.width/2), (Screen.height - exit.height - 25), exit.width, exit.height);
		if (GUI.Button (exitRect, exit, GUIStyle.none)) {
			Application.LoadLevel (0);
		}
	}
}
