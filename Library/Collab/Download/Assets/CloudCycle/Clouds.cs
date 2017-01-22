using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clouds : MonoBehaviour {
    float cspeed;
    private Rigidbody cbody;

	// Use this for initialization
	void Start () {
        cbody = GetComponent<Rigidbody>();
        cspeed = Random.Range(1f, 3.5f);
        cbody.velocity = transform.right * -cspeed;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
