using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public Button leftArrowButton, rightArrowButton, rotateLeftButton, rotateRightButton, settingButton;
    public Board board;
    public Piece activePiece;
    public Canvas dialogCanvas;

    void Awake()
    {
        Button[] buttonArray = GetComponentsInChildren<Button>();
        this.leftArrowButton = Array.Find(buttonArray, b => b.tag == "left_arrow");
        this.rightArrowButton = Array.Find(buttonArray, b => b.tag == "right_arrow");
        this.rotateLeftButton = Array.Find(buttonArray, b => b.tag == "rotate_left");
        this.rotateRightButton = Array.Find(buttonArray, b => b.tag == "rotate_right");
        this.settingButton = Array.Find(buttonArray, b => b.tag == "setting");
        Canvas[] canvasArray = GetComponentsInChildren<Canvas>();
        // this.dialogCanvas = Array.Find(canvasArray, c => c.tag == "setting_dialog");
        leftArrowButton.onClick.AddListener(MoveLeft);
        rightArrowButton.onClick.AddListener(MoveRight);
        rotateLeftButton.onClick.AddListener(RotateLeft);
        rotateRightButton.onClick.AddListener(RotateRight);
        settingButton.onClick.AddListener(OpenSettings);
        // dialogCanvas.gameObject.SetActive(false);
        dialogCanvas.enabled = false;
    }

    private void OpenSettings()
    {
        // dialogCanvas.gameObject.SetActive(true);
        dialogCanvas.enabled = true;
        if (PauseManager.instance.isPaused)
        {
            PauseManager.instance.ResumeGame();
        }
        else
        {
            PauseManager.instance.PauseGame();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void MoveLeft()
    {
        Debug.Log("Move Left button clicked!");
        // Add your logic for moving the piece left here
        this.board.Clear(activePiece);
        this.activePiece.Move(Vector3Int.left);
        this.activePiece.tryToStep();
        this.board.Set(activePiece);
    }

    public void MoveRight()
    {
        Debug.Log("Move Right button clicked!");
        // Add your logic for moving the piece right here
        this.board.Clear(activePiece);
        this.activePiece.Move(Vector3Int.right);
        this.activePiece.tryToStep();
        this.board.Set(activePiece);
    }

    public void RotateLeft()
    {
        Debug.Log("Rotate Left button clicked!");
        // Add your logic for rotating the piece left here
        this.board.Clear(activePiece);
        this.activePiece.Rotate(-1);
        this.activePiece.tryToStep();
        this.board.Set(activePiece);
    }

    public void RotateRight()
    {
        Debug.Log("Rotate Right button clicked!");
        // Add your logic for rotating the piece right here
        this.board.Clear(activePiece);
        this.activePiece.Rotate(1);
        this.activePiece.tryToStep();
        this.board.Set(activePiece);
    }

    public void Down()
    {
        Debug.Log("Down button clicked!");
        // Add your logic for moving the piece down here
        this.board.Clear(activePiece);
        this.activePiece.Move(Vector3Int.down);
        this.activePiece.tryToStep();
        this.board.Set(activePiece);
    }

    public void HardDrop()
    {
        Debug.Log("Hard Drop button clicked!");
        // Add your logic for hard dropping the piece here
        this.board.Clear(activePiece);
        this.activePiece.HardDrop();
        this.activePiece.tryToStep();
        this.board.Set(activePiece);
    }
}
