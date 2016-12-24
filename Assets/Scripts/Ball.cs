using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {

	public Vector2 ballLaunchVelocity;
	public float hitTweakThreshold;

	private Paddle paddle;
	private bool wasLaunched;

	private new Rigidbody2D rigidbody2D;

	void Start() {
		paddle = FindObjectOfType<Paddle>();
		wasLaunched = false;
		rigidbody2D = GetComponent<Rigidbody2D>();
	}

	void Update() {
		if (!wasLaunched) {
			transform.position = new Vector3(paddle.transform.position.x, transform.position.y, paddle.transform.position.z);

			if (Input.GetMouseButtonDown(0)) {
				wasLaunched = true;
				rigidbody2D.velocity = ballLaunchVelocity;
			}
		}
	}

	void OnCollisionEnter2D(Collision2D collision) {
		if (wasLaunched) {
			rigidbody2D.velocity += new Vector2(Random.Range(0.0f, hitTweakThreshold), Random.Range(0.0f, hitTweakThreshold));
		}
	}

}
