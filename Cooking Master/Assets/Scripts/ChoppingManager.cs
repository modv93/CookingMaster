using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChoppingManager : MonoBehaviour {

    [SerializeField] Text boardOneText, boardTwoText;
    private Player[] players;
    private string choppingTableOne, choppingTableTwo;
    // Use this for initialization
    void Start () {
        SetupUtilities();
	}
	
    void SetupUtilities () {
        players = FindObjectsOfType<Player>();

        //maintaining the order for players array
        if (players[1].tag == "Player 1") {
            var temp = players[0];
            players[0] = players[1];
            players[1] = temp;
        }
        choppingTableOne = "";
        choppingTableTwo = "";
    }

	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D collider) {
        if (collider.tag == "Player 1")
        {
            choppingTableOne += players[0].GetPlacingVeggie();
            boardOneText.text = choppingTableOne;
        }
        else if (collider.tag == "Player 2")
        {
            choppingTableTwo += players[1].GetPlacingVeggie();
            boardTwoText.text = choppingTableTwo;
        }
    }
}
