using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour {
	public float speed;
	private Rigidbody rb;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
		rb.velocity = transform.right * -speed;
//		InvokeRepeating ("Zigzag", 1.0f, 1.0f);

	}

	// Update is called once per frame
//	void Update () {
//		rb.position += transform.up * Time.deltaTime * speed;
//		transform.position = rb.position + -transform.right * Mathf.Sin (Time.time * 20.0f) * 0.5f;
//	}
//

}
