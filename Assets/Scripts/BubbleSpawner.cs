using UnityEngine;
using System.Collections;

public class BubbleSpawner : MonoBehaviour {
	public int startingBubbleCount = 0;
	public Transform bubblePrefab;
	public Transform gameControlScript;
	
	public void SpawnBubbles(int count)
	{
		for (int i = 0; i < startingBubbleCount; i++) {
			var newBubble = Instantiate(bubblePrefab) as Transform;
			newBubble.position = new Vector3(0, 0, i);
			newBubble.parent = this.transform;
			//newBubble.GetComponent<BubbleScript>().speed = 2.5f;
			newBubble.GetComponent<SpriteRenderer>().color = new Color(Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), 1.0f);
			newBubble.GetComponent<BubbleScript>().gameControlScript = gameControlScript;
		}
	}
}
