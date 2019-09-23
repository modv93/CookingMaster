using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    [SerializeField]private string playerName;

    private bool canMove = true;
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
}
