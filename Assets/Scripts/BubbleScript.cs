using UnityEngine;
using System.Collections;

public class BubbleScript : MonoBehaviour {
	public float speed = 5.0f;
	public Transform explosionPrefab;

	// Use this for initialization
	void Start ()
	{
		Vector2 topLeft = ScreenTopLeft ();
		Vector2 bottomRight = ScreenBottomRight ();

		Vector3 v = Quaternion.AngleAxis(Random.Range(0.0f, 360.0f), Vector3.forward) * Vector3.up;
		rigidbody2D.velocity = v * speed;

		float newX = Random.Range (topLeft.x, bottomRight.x);
		float newY = Random.Range (topLeft.y, bottomRight.y);

		this.transform.position = new Vector3 (newX, newY, this.transform.position.z);
	}

	public Vector2 ScreenTopLeft()
	{
		var leftBorder = Camera.main.ViewportToWorldPoint (
			new Vector3 (0, 0, 0)
			).x;
		var topBorder = Camera.main.ViewportToWorldPoint(
			new Vector3(0, 0, 0)
			).y;
		return new Vector2 (leftBorder, topBorder);
	}

	public Vector2 ScreenBottomRight()
	{
		var rightBorder = Camera.main.ViewportToWorldPoint(
			new Vector3(1, 0, 0)
			).x;
		var bottomBorder = Camera.main.ViewportToWorldPoint(
			new Vector3(0, 1, 0)
			).y;
		return new Vector2 (rightBorder, bottomBorder);
	}

	// Update is called once per frame
	void Update ()
	{
		Vector2 topLeft = ScreenTopLeft ();
		Vector2 bottomRight = ScreenBottomRight ();

		if (this.gameObject.transform.position.x <= topLeft.x || this.gameObject.transform.position.x >= bottomRight.x) {
			this.rigidbody2D.velocity = new Vector2(this.rigidbody2D.velocity.x * -1, this.rigidbody2D.velocity.y * 1);
		}

		if (this.gameObject.transform.position.y >= bottomRight.y || this.gameObject.transform.position.y <= topLeft.y) {
			this.rigidbody2D.velocity = new Vector2(this.rigidbody2D.velocity.x * 1, this.rigidbody2D.velocity.y * -1);
		}
	}

	void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.tag == "Explosion") {
			SpawnNewExplosion();
			Destroy(this.gameObject);
		}
	}

	void SpawnNewExplosion()
	{
		var explode = Instantiate (explosionPrefab) as Transform;
		explode.transform.position = this.transform.position;
		explode.parent = this.transform.parent;
	}
}
