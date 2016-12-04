using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class LevelManager : MonoBehaviour {

	private const string LEVEL_SCENE_FORMAT_NAME = "Level_{0:D2}";
	private const string LOSE_SCENE_NAME = "Lose";

	private const string GAME_SCENE_NAME = "Game";
	private const string WIN_SCENE_NAME = "Win";
	private const string START_SCENE_NAME = "Start";

	public void loadGameScene() {
		loadScene(GAME_SCENE_NAME);
	}

	public void loadWinScene() {
		loadScene(WIN_SCENE_NAME);
	}

	public void loadLoseScene() {
		loadScene(LOSE_SCENE_NAME);
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
}
