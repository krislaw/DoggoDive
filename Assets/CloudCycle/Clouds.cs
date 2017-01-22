using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clouds : MonoBehaviour {
    public float cspeed;
    private Rigidbody2D cbody;

	// Use this for initialization
	void Start () {
        cbody = GetComponent<Rigidbody2D>();
        cbody.velocity = transform.right * -cspeed;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
