using UnityEngine;
using System.Collections;

public class ExplosionScript : MonoBehaviour {
	public float maxScale   = 2.25f;
	public float expandRate = 0.02f;
	public float shrinkRate = 0.065f;
	public bool  expanding  = false;
	public float delay      = 1.3f;

	void Start() {
		expanding = true;
	}
	
	// Update is called once per frame
	void Update () {
		if (expanding) {
			Vector3 currentScale = this.transform.localScale;
			this.transform.localScale = new Vector3 (
				Mathf.Clamp (currentScale.x + expandRate, 0.0f, maxScale),
				Mathf.Clamp (currentScale.y + expandRate, 0.0f, maxScale),
				1.0f);
			if (currentScale.x >= maxScale) {
				expanding = false;
			}
		} else if (delay >= 0.0f) {
			delay -= 1.0f * Time.deltaTime;
		} else if (delay <= 0.0f) {
			if (this.transform.localScale.x <= 0) {
				Destroy (this.gameObject);
			} else {
				Vector3 currentScale = this.transform.localScale;
				this.transform.localScale = new Vector3 (
					Mathf.Clamp (currentScale.x - shrinkRate, 0.0f, maxScale),
					Mathf.Clamp (currentScale.y - shrinkRate, 0.0f, maxScale),
					1.0f);
			}
		}
	}
}
