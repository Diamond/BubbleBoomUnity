using UnityEngine;
using System.Collections;

public class GameControlScript : MonoBehaviour {
	public int score = 0;
	public int level = 0;
	public bool ranExplosion = false;
	public Transform bubbleSpawner;
	public Transform explosionSpawner;

	// Use this for initialization
	void Start () {
		BubbleSpawner bs = bubbleSpawner.GetComponent<BubbleSpawner> ();

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
