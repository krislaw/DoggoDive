using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

	public GUIText airLabel;
	public GUIText gameOverLabel;
	public GUIText scoreLabel;


	private bool gameEnded;
	private bool restart;

	private int air;
	private int score;

	// Use this for initialization
	void Start () {
		air = 3000;
		airLabel.text = "Air: " + air;
		gameOverLabel.text = "";
		scoreLabel.text = "Score: 0";
		score = 0;
		gameEnded = false;
		restart = false;

		StartCoroutine (SpawnWaves ());
	}
	
	// Update is called once per frame
	void Update () {
//		Debug.LogAssertion (air);
		airLabel.text = "Air: " + air;
		scoreLabel.text = "Score: " + score;

		if (restart){
			if(Input.GetKeyDown (KeyCode.R)){
				Application.LoadLevel (Application.loadedLevel);
//				SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
			}
		}
	}

	public void decreaseAir(){
		if (air > 0){
			air--;
		} else {
			gameOver ();
		}
	}

	public void increaseAir(){
		if (air < 3000){
			air += 5;
		} else {
			air = 3000;
		}
	}

	public void addScore(int newScore){
		score += newScore;
	}

	public GameObject hazard_1;
	public GameObject hazard_2;

	public Vector3 spawnValues;
	public float spawnWait;
	public float startWait;
	public float waveWait;
	public int hazardCount;

	IEnumerator SpawnWaves(){
		yield return new WaitForSeconds (startWait);
		while(!gameEnded){
			for(int i = 0; i < hazardCount; i++){

				GameObject enemy;

				if(Random.Range (0, 2) >= 1){
					enemy = hazard_1;
				} else {
					enemy = hazard_2;
				}

				Vector3 spawnPosition = new Vector3 (spawnValues.x, spawnValues.y, Random.Range (-spawnValues.z, spawnValues.z));
				Instantiate (enemy, spawnPosition, Quaternion.Euler(0, 0, 0));
				yield return new WaitForSeconds (spawnWait);
			}
			while (GameObject.FindGameObjectsWithTag("Enemy").Length != 0){
//				Debug.Log ("waiting for clones to die");
				yield return new WaitForSeconds (waveWait);
			}

			hazardCount = (int)(1.5 * hazardCount);
			Debug.Log ("next wave,,, haz::" + hazardCount);

		}
	}

	public void gameOver(){
		gameEnded = true;
		gameOverLabel.text = "Game Over!";
	}
}
