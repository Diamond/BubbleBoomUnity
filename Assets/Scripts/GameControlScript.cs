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

	private BubbleSpawner _bs;
	private ExplosionSpawner _es;
	private int _nextLevel;
	private int _totalScore = 0;

	// Use this for initialization
	void Start () {
		_bs = bubbleSpawner.GetComponent<BubbleSpawner> ();
		_es = explosionSpawner.GetComponent<ExplosionSpawner> ();

		transitionToNextLevel ();
	}
	
	// Update is called once per frame
	void Update () {
		if (score >= _nextLevel && _es.transform.childCount == 0) {
			transitionToNextLevel();
		}
	}

	public void UpdateScoreDisplay()
	{
		scoreDisplay.guiText.text = "Score " + score.ToString () + " / Next " + _nextLevel.ToString();
	}

	public void addPoint()
	{
		score++;
		UpdateScoreDisplay ();
	}

	public void transitionToNextLevel()
	{
		reset ();
		switch (level) {
		case 0:
			_bs.SpawnBubbles (10);
			_nextLevel = 1;
			break;
		case 1:
			_bs.SpawnBubbles (10);
			_nextLevel = 2;
			break;
		}
		_totalScore += score;
		score = 0;
		UpdateScoreDisplay ();
	}

	public void reset()
	{
		var children = new List<GameObject>();
		foreach (Transform child in _bs.transform) children.Add(child.gameObject);
		children.ForEach(child => Destroy(child));
	}
}
