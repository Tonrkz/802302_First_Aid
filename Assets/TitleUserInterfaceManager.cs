using UnityEngine;
using DG.Tweening;

public class TitleUserInterfaceManager : MonoBehaviour {

    [Header("References")]
    [SerializeField] RectTransform titlePanel;
    [SerializeField] RectTransform levelSelectionPanel;

    [Header("Attributes")]
    [SerializeField] int screenWidth;
    [SerializeField] float tweenDuration = 1f;

    void Start() {
        screenWidth = Screen.width;
        screenWidth = (int)(screenWidth * 1080f / Screen.height);

        titlePanel.anchoredPosition = new Vector2(0, 0);
        levelSelectionPanel.anchoredPosition = new Vector2(screenWidth, 0);
    }

    public void OnClickLevelSelectionButton() {
        titlePanel.DOAnchorPos(new Vector2(-screenWidth, 0), tweenDuration);
        levelSelectionPanel.DOAnchorPos(new Vector2(0, 0), tweenDuration);
    }

    public void OnClickMainMenuButton() {
        titlePanel.DOAnchorPos(new Vector2(0, 0), tweenDuration);
        levelSelectionPanel.DOAnchorPos(new Vector2(screenWidth, 0), tweenDuration);
    }
}
