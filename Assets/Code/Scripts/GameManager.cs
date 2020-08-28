using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
  public string prevScene = "";
  public string currentScene = "";
  // public int health = 10;
  // public int wheat = 0;

  static GameManager instance;

  public virtual void Start() {
      // Don't destroy the original GameManager
      if (instance != null) {
        Destroy(this.gameObject);
      }
      instance = this;
      GameObject.DontDestroyOnLoad(this.gameObject);
  }

  void Update() {
    // Save the current scene name
    // A per-scene SceneManager script will use this for player positioning
    currentScene = SceneManager.GetActiveScene().name;
  }

  // public void LoadScene(string sceneName) {
  //     prevScene = currentScene;
  //     SceneManager.LoadScene(sceneName);
  // }
}
