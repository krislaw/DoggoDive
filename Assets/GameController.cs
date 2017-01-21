using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

	public GUIText airLabel;
	public GUIText gameOverLabel;

	private bool gameEnded;
	private bool restart;

	private int air;

	// Use this for initialization
	void Start () {
		air = 3000;
		airLabel.text = "Air: " + air;
		gameEnded = false;
		restart = false;

		StartCoroutine (SpawnWaves ());
	}
	
	// Update is called once per frame
	void Update () {
//		Debug.LogAssertion (air);
		airLabel.text = "Air: " + air;

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

	public GameObject hazard;
	public Vector3 spawnValues;
	public float spawnWait;
	public float startWait;
	public float waveWait;
	public int hazardCount;

	IEnumerator SpawnWaves(){
		yield return new WaitForSeconds (startWait);
		while(!gameEnded){
			for(int i = 0; i < hazardCount; i++){
				Vector3 spawnPosition = new Vector3 (spawnValues.x, spawnValues.y, Random.Range (-spawnValues.z, spawnValues.z));
				Instantiate (hazard, spawnPosition, Quaternion.Euler(0, 0, 0));
				yield return new WaitForSeconds (spawnWait);
			}
			yield return new WaitForSeconds (waveWait);
		}
	}

	public void gameOver(){
		gameEnded = true;
		gameOverLabel.text = "Game Over!";
	}
}
