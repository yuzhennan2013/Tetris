using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ControlPanel : MonoBehaviour
{
    public Button leftArrowButton, rightArrowButton, rotateLeftButton, rotateRightButton, downButton;
    public Board board;
    public Piece activePiece;

    void Awake()
    {
        Button[] buttonArray = GetComponentsInChildren<Button>();
        this.leftArrowButton = Array.Find(buttonArray, b => b.tag == "left_arrow");
        this.rightArrowButton = Array.Find(buttonArray, b => b.tag == "right_arrow");
        this.rotateLeftButton = Array.Find(buttonArray, b => b.tag == "rotate_left");
        this.rotateRightButton = Array.Find(buttonArray, b => b.tag == "rotate_right");
        this.downButton = Array.Find(buttonArray, b => b.tag == "down");
        leftArrowButton.onClick.AddListener(MoveLeft);
        rightArrowButton.onClick.AddListener(MoveRight);
        rotateLeftButton.onClick.AddListener(RotateLeft);
        rotateRightButton.onClick.AddListener(RotateRight);
        downButton.onClick.AddListener(Down);
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
    }

    public void MoveRight()
    {
        Debug.Log("Move Right button clicked!");
        // Add your logic for moving the piece right here
    }

    public void RotateLeft()
    {
        Debug.Log("Rotate Left button clicked!");
        // Add your logic for rotating the piece left here
    }

    public void RotateRight()
    {
        Debug.Log("Rotate Right button clicked!");
        // Add your logic for rotating the piece right here
    }

    public void Down()
    {
        Debug.Log("Down button clicked!");
        // Add your logic for moving the piece down here
    }
}
