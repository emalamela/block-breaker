﻿using UnityEngine;
using System.Collections;

public class Brick : MonoBehaviour {

	public static int breakableCount;

	public AudioClip hitClip;
	public Sprite[] hitSprites;
	public GameObject smoke;

	private bool isBreakable;
	private int hitTimes;
	private int hitThreshold;
	private LevelManager levelManager;

	static Brick() {
		breakableCount = 0;
	}

	void Start() {
		initialize();
	}

	private void initialize() {
		hitTimes = 0;
		hitThreshold = hitSprites.Length + 1;
		isBreakable = CompareTag("Breakable");
		levelManager = FindObjectOfType<LevelManager>();

		if (isBreakable) breakableCount++;
	}

	void OnCollisionExit2D(Collision2D collision) {
		if (hitClip != null) {
			AudioSource.PlayClipAtPoint(hitClip, transform.position);
		}

		if (isBreakable) {
			handleHit();
		}
	}

	private void handleHit() {
		if (++hitTimes >= hitThreshold) {
			puffSmoke();
			Destroy(gameObject);
			breakableCount--;
			levelManager.brickDestroyed();
			return;
		}

		loadCurrentSprite();
	}

	void puffSmoke() {
		GameObject smokePuff = Instantiate(smoke, transform.position, Quaternion.identity) as GameObject;
		smokePuff.GetComponent<ParticleSystem>().startColor = GetComponent<SpriteRenderer>().color;
	}

	private void loadCurrentSprite() {
		int spriteIndex = hitTimes - 1;
		Sprite currentSprite = hitSprites[spriteIndex];

		if (currentSprite != null) {
			GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
		}
	}
}
