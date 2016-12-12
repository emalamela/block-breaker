using UnityEngine;
using System.Collections;

public class Paddle : MonoBehaviour {

	private const int GAME_WIDTH_IN_UNITS = 16;
	private const string BALL_TAG = "Ball";

	void Update() {
		updatePaddlePosition();
	}

	// Clamps the X position of the paddle to avoid it leaving the screen (this assumes paddle has 1 world unit of width)
	private void updatePaddlePosition() {
		transform.position = new Vector3(getMousePosInBlocks(), transform.position.y, 0f);
	}

	private static float getMousePosInBlocks() {
		return Input.mousePosition.x / Screen.width * GAME_WIDTH_IN_UNITS;
	}
}
