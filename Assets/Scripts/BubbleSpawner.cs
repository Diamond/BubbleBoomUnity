using UnityEngine;
using System.Collections;

public class BubbleSpawner : MonoBehaviour {
	public int startingBubbleCount = 0;
	public Transform bubblePrefab;

	// Use this for initialization
	void Start () {
		for (int i = 0; i < startingBubbleCount; i++) {
			var newBubble = Instantiate(bubblePrefab) as Transform;
			newBubble.parent = this.transform;
		}
	}
}
