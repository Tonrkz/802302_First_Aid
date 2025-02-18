﻿using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.XR;

public class CPRStageStepManager : MonoBehaviour {
    public static CPRStageStepManager instance;
    internal Enum_CPRStageStep currentStep = Enum_CPRStageStep.CheckForBreath;

    [Header("References")]
    [SerializeField] GameObject stageBackground;

    [Header("Attributes")]
    [SerializeField] internal GameObject noseHitbox;
    [SerializeField] GameObject correctCPRHitbox;
    [SerializeField] GameObject itemUsingHitbox;
    [SerializeField] GameObject assistantCPR;
    [SerializeField] List<GameObject> itemList = new List<GameObject>();

    [Header("Audio")]
    [SerializeField] AudioClip correctItemSFX;
    [SerializeField] AudioClip wrongItemSFX;

    void Awake() {
        instance = this;
    }

    void Start() {
        OnInitiateStep(currentStep);
    }

    void OnInitiateStep(Enum_CPRStageStep step) {
        switch (step) {
            case Enum_CPRStageStep.CheckForBreath:
                Debug.Log("Check for breathing");
                noseHitbox.SetActive(true);
                correctCPRHitbox.SetActive(false);
                itemUsingHitbox.SetActive(true);
                assistantCPR.SetActive(false);
                foreach (GameObject item in itemList) {
                    item.SetActive(true);
                }
                break;
            case Enum_CPRStageStep.CallAmbulance:
                Debug.Log("Call for ambulance");
                noseHitbox.SetActive(false);
                correctCPRHitbox.SetActive(false);
                itemUsingHitbox.SetActive(true);
                break;
            case Enum_CPRStageStep.FirstHandCPR:
                Debug.Log("First Hand CPR");
                noseHitbox.SetActive(false);
                correctCPRHitbox.SetActive(true);
                itemUsingHitbox.SetActive(false);
                assistantCPR.SetActive(true);
                break;
            case Enum_CPRStageStep.SecondHandCPR:
                Debug.Log("Second Hand CPR");
                noseHitbox.SetActive(false);
                correctCPRHitbox.SetActive(false);
                itemUsingHitbox.SetActive(false);
                break;
            case Enum_CPRStageStep.StartCPR:
                Debug.Log("Start CPR");
                UserInterfaceManager.instance.FadeTint(stageBackground, new Color(0.5f, 0.5f, 0.5f, 1f));
                noseHitbox.SetActive(false);
                correctCPRHitbox.SetActive(true);
                itemUsingHitbox.SetActive(false);
                CPRMinigameManager.instance.InitiateCPRMinigame();
                foreach (GameObject item in itemList) {
                    try {
                        if (item.name == "First Hand CPR" || item.name == "Second Hand CPR") {
                            Destroy(item);
                        }
                        item.SetActive(false);
                    }
                    catch (System.Exception) {
                        continue;
                    }
                }
                break;
            case Enum_CPRStageStep.FirstHandLungResuscitation:
                Debug.Log("First Hand Lung Resuscitation");
                UserInterfaceManager.instance.FadeTint(stageBackground, Color.white);
                noseHitbox.SetActive(true);
                noseHitbox.GetComponent<Collider2D>().enabled = true;
                correctCPRHitbox.SetActive(true);
                itemUsingHitbox.SetActive(true);
                foreach (GameObject item in itemList) {
                    try {
                        item.SetActive(true);
                    }
                    catch (System.Exception) {
                        continue;
                    }
                }
                break;
            case Enum_CPRStageStep.SecondHandLungResuscitation:
                Debug.Log("Second Hand Lung Resuscitation");
                noseHitbox.GetComponent<Collider2D>().enabled = false;
                noseHitbox.SetActive(true);
                correctCPRHitbox.SetActive(true);
                itemUsingHitbox.SetActive(true);
                break;
            case Enum_CPRStageStep.LungResuscitation:
                Debug.Log("Help Breathing");
                Destroy(itemList[1]);
                Destroy(itemList[2]);
                noseHitbox.SetActive(true);
                noseHitbox.GetComponentInChildren<SpriteRenderer>().color = new Color(1, 1, 1, 1);
                noseHitbox.GetComponent<Collider2D>().enabled = true;
                correctCPRHitbox.SetActive(false);
                itemUsingHitbox.SetActive(true);
                break;
            case Enum_CPRStageStep.End:
                Debug.Log("End");
                ScoreManager.instance.StageCleared();
                break;
            default:
                Debug.Log("Invalid Step");
                break;
        }
    }

    internal void OnStepWrong() {
        SFXManager.instance.PlaySFXClip(wrongItemSFX, transform, 1f);
        CPRStageCharacter.instance.OnWrongItem();
        ScoreManager.instance.SubtractScore();
    }

    internal void OnStepCompleted() {
        SFXManager.instance.PlaySFXClip(correctItemSFX, transform, 1f);
        if (currentStep == Enum_CPRStageStep.CheckForBreath || currentStep == Enum_CPRStageStep.CallAmbulance || currentStep == Enum_CPRStageStep.LungResuscitation) {
            ScoreManager.instance.AddScore();
        }
        switch (currentStep) {
            case Enum_CPRStageStep.CheckForBreath:
                UserInterfaceManager.instance.UpdateText(UserInterfaceManager.instance.updateScoreText, $"+{ScoreManager.instance.deltaScore} ตรวจสอบลมหายใจ");
                break;
            case Enum_CPRStageStep.CallAmbulance:
                UserInterfaceManager.instance.UpdateText(UserInterfaceManager.instance.updateScoreText, $"+{ScoreManager.instance.deltaScore} โทรเรียกรถพยาบาล");
                break;
            case Enum_CPRStageStep.FirstHandCPR:
                UserInterfaceManager.instance.UpdateText(UserInterfaceManager.instance.updateScoreText, $"วางมือข้างที่ไม่ถนัดลงบนหน้าอก");
                break;
            case Enum_CPRStageStep.SecondHandCPR:
                UserInterfaceManager.instance.UpdateText(UserInterfaceManager.instance.updateScoreText, $"วางมือข้างที่ถนัดลงบนมือที่วางไว้");
                break;
            case Enum_CPRStageStep.StartCPR:
                CPRMinigameManager.instance.EndCPRMinigame();
                UserInterfaceManager.instance.UpdateText(UserInterfaceManager.instance.updateScoreText, $"กดหน้าอกปั๊มหัวใจ");
                break;
            case Enum_CPRStageStep.FirstHandLungResuscitation:
                UserInterfaceManager.instance.UpdateText(UserInterfaceManager.instance.updateScoreText, $"ใช้มือข้างที่ถนัดบีบจมูก");
                break;
            case Enum_CPRStageStep.SecondHandLungResuscitation:
                UserInterfaceManager.instance.UpdateText(UserInterfaceManager.instance.updateScoreText, $"ใช้มือข้างที่ไม่ถนัดเปิดปาก");
                break;
            case Enum_CPRStageStep.LungResuscitation:
                UserInterfaceManager.instance.UpdateText(UserInterfaceManager.instance.updateScoreText, $"+{ScoreManager.instance.deltaScore} ผายปอด");
                break;
            case Enum_CPRStageStep.End:
                break;
            default:
                break;
        }
        ++currentStep;
        Debug.Log($"Step Updated!\nCurrent Step: {currentStep}");
        OnInitiateStep(currentStep);
    }
}
