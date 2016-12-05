using UnityEngine;
using System.Collections;

public class PaddleBehaviour : MonoBehaviour {

	private const int GAME_WIDTH_IN_UNITS = 16;

	public GameObject ball;
	public Vector2 ballLaunchVelocity;

	private bool hasLaunchedBall = false;

	void Update() {
		updatePaddlePosition();

		if (!hasLaunchedBall) {
			ball.transform.position = new Vector3(transform.position.x, ball.transform.position.y, transform.position.z);

			if (Input.GetMouseButtonDown(0)) {
				hasLaunchedBall = true;
				ball.GetComponent<Rigidbody2D>().velocity = ballLaunchVelocity;
			}
		}
	}

	// Clamps the X position of the paddle to avoid it leaving the screen (this assumes paddle has 1 world unit of width)
	private void updatePaddlePosition() {
		transform.position = new Vector3(getMousePosInBlocks(), transform.position.y, 0f);
	}

	private static float getMousePosInBlocks() {
		return Input.mousePosition.x / Screen.width * GAME_WIDTH_IN_UNITS;
	}
}
