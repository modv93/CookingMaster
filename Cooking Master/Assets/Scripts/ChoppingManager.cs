using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChoppingManager : MonoBehaviour {

    private Player[] players;
    private Text boardText;
    // Use this for initialization
    void Start () {
        SetupUtilities();
	}
	
    void SetupUtilities () {
        players = FindObjectsOfType<Player>();
        boardText = gameObject.GetComponentInChildren<Text>();

        //maintaining the order for players array
        if (players[1].tag == "Player 1") {
            var temp = players[0];
            players[0] = players[1];
            players[1] = temp;
        }

        boardText.text = "";
    }

	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D collider) {

        if (collider.CompareTag("Player 1")  && gameObject.CompareTag("CB_1"))
        {
            boardText.text = boardText.text + players[0].PlaceVegetableOnTable();
        }
        else if (collider.CompareTag("Player 2") && gameObject.CompareTag("CB_2"))
        {
            boardText.text = boardText.text + players[1].PlaceVegetableOnTable();
        }
    }

}
