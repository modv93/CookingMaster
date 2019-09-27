using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {

    [SerializeField]private string playerName;
    [SerializeField] private Text playerItemDisplay;

    private bool canMove = true;
    private string vegetablesPicked = null;
    private const int MAX_PICKUP_VEGGIES = 1;

	// Use this for initialization
	void Start () {
        GetComponentInChildren<TextMesh>().text = playerName;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public bool CanMove () {
        return canMove;
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        Debug.LogWarning("Enter T" + vegetablesPicked);
        VeggiesPickup(collider);
        ShowPickups();
    }

    private void VeggiesPickup(Collider2D collider)
    {
        //Checking whether this veggie can be picked up
        if( vegetablesPicked != null ) {
            if (CanNotBePicked(collider)) { return; }
        }

        if (gameObject.tag == "Player 1" && collider.tag == "Veggie") {
            vegetablesPicked = collider.gameObject.name + vegetablesPicked;
            Debug.LogWarning("Pick Up P1" + vegetablesPicked);
        }
        else if (gameObject.tag == "Player 2" && collider.tag == "Veggie") {
            vegetablesPicked = collider.gameObject.name + vegetablesPicked;
            Debug.LogWarning("Pick Up P2" + vegetablesPicked);
        }

    }

    private void ShowPickups () {
        playerItemDisplay.text = vegetablesPicked;
    }

    private bool CanNotBePicked(Collider2D collider) {
        if(vegetablesPicked.Contains(collider.gameObject.name) || vegetablesPicked.Length >= MAX_PICKUP_VEGGIES + 1) {
            return true;
        }
        return false;
    }

    public string GetPlacingVeggie () {
        if(vegetablesPicked == null) { return ""; }

        string veggie = "";

        if (vegetablesPicked.Length == 2) {
            veggie = vegetablesPicked[0].ToString();
            vegetablesPicked = vegetablesPicked[0].ToString();
        }
        else if(vegetablesPicked.Length == 1) {
            veggie = vegetablesPicked[0].ToString();
            vegetablesPicked = "";
        }

        ShowPickups();
        return veggie;
    }
}
