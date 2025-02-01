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
            Destroy(this);
        }
        DontDestroyOnLoad(this);
    }

    public void PlaySFXClip(AudioClip audioClip, Transform spawnTransform, float volume) {
        AudioSource audioSource = Instantiate(SFXObject, spawnTransform.position, Quaternion.identity);
        audioSource.clip = audioClip;
        audioSource.volume = volume;
        audioSource.Play();
        Destroy(audioSource.gameObject, audioClip.length);
    }
}
