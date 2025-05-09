﻿using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CPR_MouthScript : MonoBehaviour, IPointerDownHandler, IPointerUpHandler {
    [Header("References")]
    [SerializeField] GameObject breathingPanel;
    [SerializeField] GameObject checkForBreathingHand;
    [SerializeField] GameObject firstLungResuscitationHand;
    [SerializeField] GameObject secondLungResuscitationHand;

    [Header("Attributes")]
    [SerializeField] byte helpBreathingCount = 2;
    [SerializeField] bool isMousePressed = false;
    bool isRun = false;

    [Header("Audio")]
    [SerializeField] AudioClip correctSFX;
    [SerializeField] AudioClip heartBeatSFX;
    [SerializeField] AudioClip breathingSFX;

    void Start() {
        breathingPanel.SetActive(false);
    }

    void Update() {
        if (isMousePressed && CPRStageStepManager.instance.currentStep == Enum_CPRStageStep.LungResuscitation) {
            HelpBreathing();
        }
    }

    void OnTriggerStay2D(Collider2D other) {
        switch (CPRStageStepManager.instance.currentStep) {
            case Enum_CPRStageStep.CheckForBreath:
                if (other.GetComponent<DragableItem>() != null) {
                    if (!other.GetComponent<DragableItem>().isDragging && other.gameObject == checkForBreathingHand) {
                        other.gameObject.GetComponent<IUseable>().UseItem();
                    }
                    else if (!other.GetComponent<DragableItem>().isDragging) {
                        CPRStageStepManager.instance.OnStepWrong();
                    }
                }
                break;
            case Enum_CPRStageStep.FirstHandLungResuscitation:
                if (other.GetComponent<DragableItem>() != null) {
                    if (!other.GetComponent<DragableItem>().isDragging && other.gameObject == firstLungResuscitationHand) {
                        other.gameObject.GetComponent<IUseable>().UseItem();
                    }
                    else if (!other.GetComponent<DragableItem>().isDragging) {
                        CPRStageStepManager.instance.OnStepWrong();
                    }
                }
                break;
            case Enum_CPRStageStep.SecondHandLungResuscitation:
                if (other.GetComponent<DragableItem>() != null) {
                    if (!other.GetComponent<DragableItem>().isDragging && other.gameObject == secondLungResuscitationHand) {
                        other.gameObject.GetComponent<IUseable>().UseItem();
                    }
                    else if (!other.GetComponent<DragableItem>().isDragging) {
                        CPRStageStepManager.instance.OnStepWrong();
                    }
                }
                break;
            default:
                if (other.GetComponent<DragableItem>() != null) {
                    if (!other.GetComponent<DragableItem>().isDragging) {
                        CPRStageStepManager.instance.OnStepWrong();
                    }
                }
                break;
        }
    }

    public void OnPointerDown(PointerEventData eventData) {
        switch (CPRStageStepManager.instance.currentStep) {
            //    case Enum_CPRStageStep.CheckForBreath: // Check for breathing
            //        CPRStageCharacter.instance.OnCorrectItemForEachStep();
            //        GetComponent<Collider2D>().enabled = false;
            //        break;
            case Enum_CPRStageStep.LungResuscitation: // Help Breathing
                isMousePressed = true;
                breathingPanel.GetComponent<Slider>().value = 0;
                breathingPanel.SetActive(true);
                break;
            default:
                break;
        }
    }

    public void OnPointerUp(PointerEventData eventData) {
        isMousePressed = false;
        isRun = false;
        breathingPanel.SetActive(false);
        CPRStageCharacter.instance.OnStopHelpBreathing();
    }

    void HelpBreathing() {
        breathingPanel.SetActive(true);
        if (!isRun) {
            CPRStageCharacter.instance.OnHelpBreathing();
            isRun = true;
        }
        breathingPanel.GetComponent<Slider>().value += Time.deltaTime;
        breathingPanel.GetComponent<Slider>().fillRect.GetComponent<Image>().color = Color.Lerp(Color.yellow, Color.green, breathingPanel.GetComponent<Slider>().value);
        if (breathingPanel.GetComponent<Slider>().value >= 1) {
            isMousePressed = false;
            helpBreathingCount--;
            if (helpBreathingCount != 0) {
                SFXManager.instance.PlaySFXClip(correctSFX, transform, 1f);
            }
            if (helpBreathingCount == 0) {
                CPRStageStepManager.instance.noseHitbox.GetComponentInChildren<SpriteRenderer>().color = new Color(1, 1, 1, 0);
                UserInterfaceManager.instance.UpdateText(UserInterfaceManager.instance.updateScoreText, $"ผายปอด");
                SFXManager.instance.PlaySFXClip(correctSFX, transform, 1f);
                SFXManager.instance.PlayLoopSFXClip(heartBeatSFX, transform, 0.75f, 5);
                SFXManager.instance.PlayLoopSFXClip(breathingSFX, transform, 1f, 2);
                CPRStageCharacter.instance.OnCorrectItemForEachStep();
            }
        }
    }
}
