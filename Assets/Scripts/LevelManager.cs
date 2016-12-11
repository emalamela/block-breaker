using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class LevelManager : MonoBehaviour {

	private const string LEVEL_SCENE_FORMAT_NAME = "level_{0:D2}";
	private const string LOSE_SCENE_NAME = "lose";

	private const string GAME_SCENE_NAME = "game";
	private const string WIN_SCENE_NAME = "win";
	private const string START_SCENE_NAME = "start";

	void Start() {
		BrickBehaviour.breakableCount = 0;
	}

	public void loadGameScene() {
		loadScene(GAME_SCENE_NAME);
	}

	public void loadWinScene() {
		loadScene(WIN_SCENE_NAME);
	}

	public void loadLoseScene() {
		// TODO: Make a lose scene
		loadScene(WIN_SCENE_NAME);
	}

	public void loadStartScene() {
		loadScene(START_SCENE_NAME);
	}

	private void loadScene(string sceneName) {
		var activeSceneName = SceneManager.GetActiveScene().name;
		if (activeSceneName.ToLower().Equals(sceneName.ToLower())) {
			print("Scene with name " + activeSceneName + " is already loaded.");
			return;
		}

		SceneManager.LoadScene(sceneName);
	}

	public void quitGame() {
		Application.Quit();
	}

	public void loadLevel(int level) {
		loadScene(string.Format(LEVEL_SCENE_FORMAT_NAME, level));
	}

	public void loadNextLevel() {
  		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
  	}
 	
 	public void brickDestroyed() {
 		if (BrickBehaviour.breakableCount <= 0) {
 			loadNextLevel();
		}
	}
}
