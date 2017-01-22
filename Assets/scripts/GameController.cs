using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

	public GUIText airLabel;
	public GUIText gameOverLabel;
	public GUIText scoreLabel;

	public GUITexture airBar;

	private bool gameEnded;
	private bool restart;

	public int maxAir;
	private int air;
	private int score;

	public GameObject player;

	public Material fadeMaterial;
	private ScreenFader fade;

	// Use this for initialization
	void Start () {
		air = maxAir;
		airLabel.text = "Air: " + air;
		gameOverLabel.text = "";
		scoreLabel.text = "Score: 0";
		score = 0;
		gameEnded = false;
		restart = false;

		fade = gameObject.AddComponent<ScreenFader>();
		fade.fadeMaterial = fadeMaterial;

		currentWave = 1;
//		StartCoroutine (SpawnWaves ());
	}
	
	// Update is called once per frame
	void Update () {
		//update labels
		airLabel.text = "Air: " + air;
		scoreLabel.text = "Score: " + score;

		//update air bar
		float percentAir = (float) air / (float) maxAir;
		Rect rect = airBar.pixelInset;
		rect.width = 300 * percentAir;
		airBar.pixelInset = rect;
		

		//game restart
		if (restart){
			if(Input.GetKeyDown (KeyCode.R)){
				Application.LoadLevel (Application.loadedLevel);
				Time.timeScale = 1;
			}
		}
	}

	public void decreaseAir(){
		if (!gameEnded) {
			if (air > 0) {
				air--;
			} else {
				gameOver ();
			}
		}
	}

	public void increaseAir(){
		if (air < maxAir){
			air += 5;
		} else {
			air = maxAir;
		}
	}

	public void addScore(int newScore){
		score += newScore;
	}
		
	public GameObject[] hazards = new GameObject[4];

	public Vector3 spawnValues;
	public float spawnWait;
	public float startWait;
	public float waveWait;
	public int hazardCount;

	private int currentWave;

	IEnumerator SpawnWaves(){
		yield return new WaitForSeconds (startWait);

		while(!gameEnded){
			for(int i = 0; i < hazardCount; i++){
				GameObject enemy = hazards [Random.Range (0, currentWave)];

				Vector3 spawnPosition = new Vector3 (spawnValues.x, spawnValues.y, Random.Range (-spawnValues.z, spawnValues.z));
				Instantiate (enemy, spawnPosition, Quaternion.Euler(0, 0, 0));
				yield return new WaitForSeconds (spawnWait);
			}
			while (GameObject.FindGameObjectsWithTag("Enemy").Length != 0){
				yield return new WaitForSeconds (waveWait);
			}

			hazardCount = (int)(1.5 * hazardCount);
			if (currentWave < hazards.Length){
				currentWave++;
			}
			Debug.Log ("wave " + currentWave +", hazard count:" + hazardCount);
		}
	}

	public AudioClip clip;

	public void gameOver(){
		AudioSource.PlayClipAtPoint (clip, new Vector3(0, 0, 0));
		GetComponent <AudioSource> ().Stop ();

		gameEnded = true;
		restart = true;
		gameOverLabel.text = "Game Over! \n Press R to restart!";

		foreach (GameObject enemy in GameObject.FindGameObjectsWithTag("Enemy")){
			Destroy (enemy);
		}

		Destroy (player);

		//fade to black here???
		fade.fadeIn = false;
	}
}
