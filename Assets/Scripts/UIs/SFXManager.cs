using UnityEngine;

public class SFXManager : MonoBehaviour {
    public static SFXManager instance;

    [Header("References")]
    [SerializeField] AudioSource SFXObject;

    void Awake() {
        if (instance == null) {
            instance = this;
        }
        else {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
        
    }

    public void PlaySFXClip(AudioClip audioClip, Transform spawnTransform, float volume) {
        AudioSource audioSource = Instantiate(SFXObject, spawnTransform.position, Quaternion.identity);
        audioSource.ignoreListenerPause = true;
        DontDestroyOnLoad(audioSource.gameObject);
        audioSource.clip = audioClip;
        audioSource.volume = volume;
        audioSource.Play();
        Destroy(audioSource.gameObject, audioClip.length);
    }

    public void PlayLoopSFXClip(AudioClip audioClip, Transform spawnTransform, float volume, int loopCount) {
        AudioSource audioSource = Instantiate(SFXObject, spawnTransform.position, Quaternion.identity);
        audioSource.ignoreListenerPause = true;
        DontDestroyOnLoad(audioSource.gameObject);
        audioSource.clip = audioClip;
        audioSource.volume = volume;
        audioSource.loop = true;
        audioSource.Play();
        Destroy(audioSource.gameObject, audioClip.length * loopCount);
    }
}
