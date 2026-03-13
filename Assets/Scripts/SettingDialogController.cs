using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class SettingDialogController : MonoBehaviour
{
    public Button cancelButton, okButton;
    public Canvas dialogCanvas;
    public TMP_InputField velocityInputField;
    public Piece activePiece;

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
        Debug.Log("velocity: " + velocityInputField.text);
        if (float.TryParse(velocityInputField.text, out float velocity))
        {
            if (velocity > 0)
            {
                activePiece.setStepDelay(1f - (velocity - 1f) * 0.1f);
            }
        }
    }

    private void Cancel()
    {
        this.dialogCanvas.enabled = false;
        PauseManager.instance.ResumeGame();
    }
}
