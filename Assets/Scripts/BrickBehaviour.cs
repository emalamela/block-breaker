using UnityEngine;
using System.Collections;

public class BrickBehaviour : MonoBehaviour {

	public Sprite[] hitSprites;

	private bool isBreakable;
	private int hitTimes;
	private int hitThreshold;

	void Start() {
		hitTimes = 0;
		hitThreshold = hitSprites.Length + 1;	
		isBreakable = CompareTag("Breakable");
	}

	void OnCollisionExit2D(Collision2D collision) {
		if (isBreakable) {
			handleHit();
		}
	}

	private void handleHit() {
		if (++hitTimes >= hitThreshold) {
			Destroy(gameObject);
			return;
		}

		loadCurrentSprite();
	}

	private void loadCurrentSprite() {
		int spriteIndex = hitTimes - 1;
		Sprite currentSprite = hitSprites[spriteIndex];
		if (currentSprite != null) {
			GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
		}
	}
}
