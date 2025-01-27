using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour {
    public static UIManager instance;

    [SerializeField] string titleScene = "TitleScene";
    [SerializeField] string levelSelectScene = "LevelSelectScene";
    [SerializeField] string scratchStageScene = "ScratchStageScene";
    [SerializeField] string burnStageScene = "BurnStage";
    [SerializeField] string cprStageScene = "CPRStage";


    void Awake() {
        if (instance == null) {
            instance = this;
        }
        else {
            Destroy(this);
        }
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
    