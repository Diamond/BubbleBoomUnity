using UnityEngine;
using System.Collections;

public class ExplosionSpawner : MonoBehaviour {
	public bool addedExplosion = false;
	public Transform explosionPrefab;

	void Update()
	{
		if (Input.touchCount > 0 && Input.GetTouch (0).phase == TouchPhase.Began) {
			var touchPos = Camera.main.ScreenToWorldPoint(Input.GetTouch (0).position);
			ExplodeAt (touchPos);
		}
		if (Input.GetMouseButtonDown (0)) {
			var mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			ExplodeAt(mousePos);
		}
	}

	void ExplodeAt(Vector3 position)
	{
		if (!HasAnyExplosions ()) {
			var explosion = Instantiate (explosionPrefab, new Vector3 (position.x, position.y, 0), Quaternion.identity) as Transform;
			explosion.parent = this.transform;
			addedExplosion = true;
		}
	}

	public bool HasAnyExplosions()
	{
		return (this.transform.childCount > 0);
	}
}
