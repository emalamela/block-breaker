using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {

	public Vector2 ballLaunchVelocity;

	private Paddle paddle;
	private bool wasLaunched;

	void Start() {
		paddle = FindObjectOfType<Paddle>();
		wasLaunched = false;
	}

	void Update() {
		if (!wasLaunched) {
			transform.position = new Vector3(paddle.transform.position.x, transform.position.y, paddle.transform.position.z);

			if (Input.GetMouseButtonDown(0)) {
				wasLaunched = true;
				GetComponent<Rigidbody2D>().velocity = ballLaunchVelocity;
			}
		}
	}

}
