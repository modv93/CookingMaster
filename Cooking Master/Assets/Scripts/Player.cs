using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {

    [SerializeField]private string playerName;
    [SerializeField] private Text playerItemDisplay;

    private bool canMove = true;
    private string vegetablesPicked = null;
    private const int MAX_PICKUP_VEGGIES = 2;

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

    void OnTriggerStay2D(Collider2D collider)
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

        if (Input.GetKeyUp(KeyCode.Space) && gameObject.tag == "Player 1") {
            vegetablesPicked = collider.gameObject.name = vegetablesPicked;
            Debug.LogWarning("Pick Up P1" + vegetablesPicked);
        }
        else if (Input.GetKeyUp(KeyCode.Return) && gameObject.tag == "Player 2") {
            vegetablesPicked = collider.gameObject.name = vegetablesPicked;
            Debug.LogWarning("Pick Up P2" + vegetablesPicked);
        }

    }

    private void ShowPickups () {
        playerItemDisplay.text = vegetablesPicked;
    }

    private bool CanNotBePicked(Collider2D collider) {
        if(vegetablesPicked.Contains(collider.gameObject.name) || vegetablesPicked.Length >= MAX_PICKUP_VEGGIES) {
            return true;
        }
        return false;
    }
}
