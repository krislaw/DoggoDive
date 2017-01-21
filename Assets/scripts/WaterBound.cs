using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterBound : MonoBehaviour {

	private GameController gameController;

	void OnTriggerStay(Collider other){
		if (other.tag == "Player"){
//			Debug.LogAssertion ("player in water");
			gameController.decreaseAir();
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
