using TMPro;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour {
    public static UIManager instance;

    void Awake() {
        if (instance == null) {
            instance = this;
        }
        else {
            Destroy(this);
        }
    }

    public void ScaleUpUI(GameObject ui) {
        ui.transform.localScale = new Vector3(1.1f, 1.1f, 1.1f);
    }

    public void ScaleDownUI(GameObject ui) {
        ui.transform.localScale = new Vector3(1f, 1f, 1f);
    }

    public void ToggleUI(GameObject ui) {
        ui.SetActive(!ui.activeSelf);
    }

    public void PauseGame() {
        Time.timeScale = 0;
    }

    public void ResumeGame() {
        Time.timeScale = 1;
    }

    public void LoadSceneViaName(string sceneName) {
        SceneManager.LoadScene(sceneName);
    }

    public void LoadSceneViaIndex(int sceneIndex) {
        SceneManager.LoadScene(sceneIndex);
    }
}
    