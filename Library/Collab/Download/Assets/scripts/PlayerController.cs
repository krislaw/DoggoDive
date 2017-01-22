using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Boundary {
	public float xMin, xMax, zMin, zMax;
}

public class PlayerController : MonoBehaviour {
	public Boundary boundary;
	private Rigidbody rb;

	public float speed;
//	public GameObject gameObject;


	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
	}

	void FixedUpdate(){
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");
		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);

		rb.velocity = movement * speed;
		rb.position = new Vector3 (Mathf.Clamp (rb.position.x, boundary.xMin, boundary.xMax), 0.0f, Mathf.Clamp (rb.position.z, boundary.zMin, boundary.zMax));
	}

	public GameObject bork;
	public Transform shotSpawn;
	public float fireRate;
	private float nextFire;

	// Update is called once per frame
	void Update () {
		if (Input.GetButton("Jump") && Time.time > nextFire){
//			Debug.LogAssertion ("FIRE??");
			nextFire = Time.time + fireRate;
			Instantiate (bork, shotSpawn.position, shotSpawn.rotation);
			GetComponent<AudioSource> ().Play ();
		}
	}

}
