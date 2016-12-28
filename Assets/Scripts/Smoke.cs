using UnityEngine;
using System.Collections;

public class Smoke : MonoBehaviour {

	private ParticleSystem particles;

	void Start () {
		particles = GetComponent<ParticleSystem>();
	}
	
	void Update () {
		if (!particles.IsAlive()) {
			Destroy(gameObject);
		}
	}
}
