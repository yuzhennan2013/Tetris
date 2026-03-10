using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SettingDialogController : MonoBehaviour
{
    public Button cancelButton, okButton;
    public Canvas dialogCanvas;

    void Awake()
    {
        Button[] buttonArray = GetComponentsInChildren<Button>();
        this.cancelButton = Array.Find(buttonArray, b => b.tag == "cancel");
        this.okButton = Array.Find(buttonArray, b => b.tag == "ok");
        this.dialogCanvas = GetComponentInChildren<Canvas>();
        cancelButton.onClick.AddListener(Cancel);
        okButton.onClick.AddListener(OK);
    }

    private void OK()
    {
        this.dialogCanvas.enabled = false;
        PauseManager.instance.ResumeGame();
    }

    private void Cancel()
    {
        this.dialogCanvas.enabled = false;
        PauseManager.instance.ResumeGame();
    }
}
