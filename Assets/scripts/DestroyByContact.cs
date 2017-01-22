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

	public GameObject explosion_1;
	public GameObject explosion_2;
	private GameObject explosion;

	private GameController gameController;
	public int score;

	public AudioClip clip;

	void OnTriggerEnter(Collider other) {
		if (other.tag == "Bound" || other.tag == "WaterBound" || other.tag == "Enemy" || other.tag == "cloud"){
			return;
		} else if (other.tag == "AirBound"){
			Destroy (gameObject);
			return;
		}else if (other.tag == "Player") {
//			Instantiate (playerExplosion, other.transform.position, transform.rotation);
			gameController.gameOver ();
		} 


		if(Random.Range (0, 2) >= 1){
			explosion = explosion_1;
		} else {
			explosion = explosion_2;
		}

		AudioSource.PlayClipAtPoint (clip, new Vector3(0, 0, 0));
		Instantiate (explosion, transform.position, transform.rotation);
		Destroy(other.gameObject);
		Destroy(gameObject);


		if (other.tag == "bolt"){
			gameController.addScore (score);
		}

	}
}
