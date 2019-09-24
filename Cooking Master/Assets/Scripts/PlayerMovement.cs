using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    [SerializeField] GameObject playerOne, playerTwo;
    private Rigidbody2D playerOneRBody, playerTwoRBody;
    private float playerSpeed = 5.0f;
    // Use this for initialization
    void Start () {
        SetupUtilities();
    }
    private void SetupUtilities()
    {
        if(!playerOne || !playerTwo) { playerOne = GameObject.FindGameObjectWithTag("Player 1"); }
        if (!playerOne || !playerTwo) { playerTwo = GameObject.FindGameObjectWithTag("Player 2"); }

        playerOneRBody = playerOne.GetComponent<Rigidbody2D>();
        playerTwoRBody = playerTwo.GetComponent<Rigidbody2D>();
        if (!playerOneRBody || !playerTwoRBody) {
            return;
        }
    }
    // Update is called once per frame
    void FixedUpdate () {
        Move();
    }
    void Move () {
        // Store the current horizontal input in the float moveHorizontal.
        float moveHorizontalPlayerOne = Input.GetAxis("P1_Horizontal");
        float moveHorizontalPlayerTwo = Input.GetAxis("P2_Horizontal");

        // Store the current vertical input in the float moveVertical.
        float moveVerticalPlayerOne = Input.GetAxis("P1_Vertical");
        float moveVerticalPlayerTwo = Input.GetAxis("P2_Vertical");

        // Use the two store floats to create a new Vector2 variable movement.
        Vector2 movementPlayerOne = new Vector2(moveHorizontalPlayerOne, moveVerticalPlayerOne);
        Vector2 movementPlayerTwo = new Vector2(moveHorizontalPlayerTwo, moveVerticalPlayerTwo);

        // Set the position of our player as per the movements keeping it framerate independent.
        if (playerOne.GetComponent<Player>().CanMove()) {
            playerOneRBody.position += Time.deltaTime * movementPlayerOne * playerSpeed;
        }
        if (playerTwo.GetComponent<Player>().CanMove()) {
            playerTwoRBody.position += Time.deltaTime * movementPlayerTwo * playerSpeed;
        }
        
    }
}
