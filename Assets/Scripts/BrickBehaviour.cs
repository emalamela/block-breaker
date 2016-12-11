using UnityEngine;
using System.Collections;

public class BrickBehaviour : MonoBehaviour {

	public Sprite[] hitSprites;

	private int hitTimes;
	private int hitThreshold;

	void Start() {
		hitTimes = 0;
		hitThreshold = hitSprites.Length + 1;	
	}

	void OnCollisionExit2D(Collision2D collision) {
		if(++hitTimes >= hitThreshold) {
			Destroy(gameObject);
			return;
		}

		loadCurrentSprite();
	}

	private void loadCurrentSprite() {
		int spriteIndex = hitTimes - 1;
		GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
	}
}
