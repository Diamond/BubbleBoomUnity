using UnityEngine;
using System.Collections;

public class GameControlScript : MonoBehaviour {
	public int score = 0;
	public int level = 0;
	public bool ranExplosion = false;
	public Transform bubbleSpawner;
	public Transform explosionSpawner;
	private BubbleSpawner _bs;
	private ExplosionSpawner _es;

	// Use this for initialization
	void Start () {
		_bs = bubbleSpawner.GetComponent<BubbleSpawner> ();
		_es = explosionSpawner.GetComponent<ExplosionSpawner> ();
		_bs.SpawnBubbles (10);
	}
	
	// Update is called once per frame
	void Update () {
	}
}
