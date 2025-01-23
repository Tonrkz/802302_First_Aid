using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManager : MonoBehaviour {
    public void GoToTitleScene() {
        UnityEngine.SceneManagement.SceneManager.LoadScene("TitleScene");
    }

    public void GoToLevelSelectScene() {
        UnityEngine.SceneManagement.SceneManager.LoadScene("LevelSelectScene");
    }

    public void GoToScratchStageScene() {
        UnityEngine.SceneManagement.SceneManager.LoadScene("ScratchStageScene");
    }

    public void GoToBurnStage() {
        UnityEngine.SceneManagement.SceneManager.LoadScene("BurnStage");
    }

    public void GoToCPRStage() {
        UnityEngine.SceneManagement.SceneManager.LoadScene("CPRStage");
    }
}
