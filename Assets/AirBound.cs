using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirBound : MonoBehaviour {

	private GameController gameController;

	void OnTriggerStay(Collider other){
		if (other.tag == "Player"){
//			Debug.LogAssertion ("player in air");
			gameController.increaseAir();

		}
	}

	void Start () {
		GameObject game = GameObject.FindWithTag ("GameController");
		if (game != null){
			gameController = game.GetComponent<GameController>();
		} else {
			Debug.LogError ("No game controller???");
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
