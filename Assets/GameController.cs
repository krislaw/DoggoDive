using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

	public GUIText airLabel;
//	public GUIText score;

	private int air;

	// Use this for initialization
	void Start () {
		air = 3000;
		airLabel.text = "Air: " + air;
	}
	
	// Update is called once per frame
	void Update () {
//		Debug.LogAssertion (air);
		airLabel.text = "Air: " + air;
	}

	public void decreaseAir(){
		if (air > 0){
			air--;
		} else {
			//game over
		}
	}

	public void increaseAir(){
		if (air < 3000){
			air += 5;
		} else {
			air = 3000;
		}
	}
}
