using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//something hits an enemy
public class DestroyByContact : MonoBehaviour {

	// Use this for initialization
	void Start () {
		GameObject game = GameObject.FindWithTag ("GameController");
		if(game != null){
			gameController = game.GetComponent<GameController>();
		}
	}

	// Update is called once per frame
	void Update () {

	}

//	public GameObject explosion;
//	public GameObject playerExplosion;
	private GameController gameController;
	public int score;

	void OnTriggerEnter(Collider other) {
		if (other.tag == "Bound" || other.tag == "WaterBound" || other.tag == "Enemy"){
			return;
		} else if (other.tag == "AirBound"){
			Destroy (gameObject);
			return;
		}else if (other.tag == "Player") {
//			Instantiate (playerExplosion, other.transform.position, transform.rotation);
			gameController.gameOver ();
		} 

//		Instantiate (explosion, transform.position, transform.rotation);
		Destroy(other.gameObject);
		Destroy(gameObject);


		if (other.tag == "bolt"){
			gameController.addScore (score);
		}

	}
}
