using UnityEngine;

public class BGMManager : MonoBehaviour {
    public static BGMManager instance;

    [Header("References")]
    [SerializeField] public AudioSource BGMObject;

    [Header("Audio")]
    [SerializeField] internal AudioClip mainMenuBGM;
    [SerializeField] internal AudioClip inGameBGM;
    [SerializeField] internal AudioClip stageClearedBGM;
    [SerializeField] internal AudioClip stageFailedBGM;

    string sceneName;

    void Awake() {
        if (instance == null) {
            instance = this;
        }
        else {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }

    void Start() {
        BGMObject = GetComponent<AudioSource>();
        BGMObject.loop = true;
        BGMObject.volume = 0.125f;
        BGMObject.ignoreListenerPause = true;

        CheckScene();

        UnityEngine.SceneManagement.SceneManager.sceneLoaded += (scene, mode) => {
            CheckScene();
        };
    }

    void CheckScene() {
        sceneName = UnityEngine.SceneManagement.SceneManager.GetActiveScene().name;

        switch (sceneName) {
            case "TitleScene":
                PlayBGMClip(mainMenuBGM);
                break;
            case "BurnStage":
                PlayBGMClip(inGameBGM);
                break;
            case "BurnStageSFXTest":
                PlayBGMClip(inGameBGM);
                break;
            case "CPRStage":
                PlayBGMClip(inGameBGM);
                break;
            case "ScratchStageScene":
                PlayBGMClip(inGameBGM);
                break;
            default:
                PlayBGMClip(mainMenuBGM);
                break;
        }
    }

    public void PlayBGMClip(AudioClip bgm) {
        BGMObject.clip = bgm;
        BGMObject.Play();
    }
}
