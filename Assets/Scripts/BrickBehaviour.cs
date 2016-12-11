using UnityEngine;
using System.Collections;

public class BrickBehaviour : MonoBehaviour {

	public static int breakableCount;

	public Sprite[] hitSprites;

	private bool isBreakable;
	private int hitTimes;
	private int hitThreshold;
	private LevelManager levelManager;

	static BrickBehaviour() {
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
		if (isBreakable) {
			handleHit();
		}
	}

	private void handleHit() {
		if (++hitTimes >= hitThreshold) {
			Destroy(gameObject);
			breakableCount--;
			levelManager.brickDestroyed();
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
