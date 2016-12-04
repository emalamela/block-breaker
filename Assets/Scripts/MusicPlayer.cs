using UnityEngine;
using System.Collections;

public class MusicPlayer : MonoBehaviour {

	void Start () {
		GameObject.DontDestroyOnLoad(gameObject);
	}
	
}
