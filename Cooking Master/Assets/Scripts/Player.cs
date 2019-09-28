using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {

    [SerializeField]private string playerName;
    [SerializeField] private Text playerItemDisplay;

    private bool canMove = true;
    public string vegetablesPicked = null;
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
        VeggiesPickup(collider);
        ShowPickups();
    }

    private void VeggiesPickup(Collider2D collider)
    {
        //Checking whether this veggie can be picked up
        if( vegetablesPicked != null ) {
            if (CanNotBePicked(collider)) { return; }
        }

        if ( gameObject.CompareTag("Player 1") && collider.CompareTag("Veggie") ) {
            vegetablesPicked = collider.gameObject.name + vegetablesPicked;
        }
        else if ( gameObject.CompareTag("Player 2") && collider.CompareTag("Veggie") ) {
            vegetablesPicked = collider.gameObject.name + vegetablesPicked;
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

    public string PlaceVegetableOnTable() {
        if(vegetablesPicked == null) { return ""; }

        string veggie = "";
        if (vegetablesPicked.Length == 2) {
            veggie = vegetablesPicked[0].ToString();
            vegetablesPicked = vegetablesPicked[1].ToString();
        }
        else if(vegetablesPicked.Length == 1) {
            veggie = vegetablesPicked[0].ToString();
            vegetablesPicked = "";
        }

        ShowPickups();
        return veggie;
    }
}
