using UnityEngine;
using System.Collections;

public class LoseOnCollision : MonoBehaviour {

	void OnTriggerEnter2D (Collider2D trigger) {
		LevelManager levelManager = GameObject.FindObjectOfType<LevelManager>();
		levelManager.loadLoseScene();
	}

}
