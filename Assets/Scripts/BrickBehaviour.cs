using UnityEngine;
using System.Collections;

public class BrickBehaviour : MonoBehaviour {

	public int hitThreshold;

	[SerializeField]
	private int hitTimes;

	void Start() {
		hitTimes = 0;	
	}

	void OnCollisionEnter2D(Collision2D collision) {
		hitTimes++;
	}

}
