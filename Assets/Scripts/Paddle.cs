﻿using UnityEngine;
using System.Collections;

public class Paddle : MonoBehaviour {

	private const int GAME_WIDTH_IN_UNITS = 16;
	private const string BALL_TAG = "Ball";

	public bool autoPlay;

	private Ball ball;

	private float lowerXBound;
	private float upperXBound;

	void Start() {
		ball = GameObject.FindObjectOfType<Ball>();
		Renderer renderer = GetComponent<Renderer>();
		lowerXBound = renderer.bounds.extents.x;
		upperXBound = GAME_WIDTH_IN_UNITS - lowerXBound;
	}

	void Update() {
		if (autoPlay) {
			updatePositionWithBall();
		} else {
			updatePositionWithMouse();
		}
	}

	private void updatePositionWithMouse() {
		clampUpdatePosition(getMousePosInBlocks());
	}

	private static float getMousePosInBlocks() {
		return Input.mousePosition.x / Screen.width * GAME_WIDTH_IN_UNITS;
	}

	private void updatePositionWithBall() {
		clampUpdatePosition(ball.transform.position.x);
	}

	// Clamps the X position of the paddle to avoid it leaving the screen (this assumes paddle has 1 world unit of width)
	private void clampUpdatePosition(float x) {
		transform.position = 
				new Vector3(
						Mathf.Clamp(x, lowerXBound, upperXBound), 
						transform.position.y, 
						0f);
	}
}
