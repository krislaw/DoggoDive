using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bound : MonoBehaviour {
	void OnTriggerExit(Collider other){
		Debug.LogAssertion (other.name + "Hit Bound");
		Destroy (other.gameObject);
	}


}
