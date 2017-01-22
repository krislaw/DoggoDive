using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudSpawm : MonoBehaviour {

    public GameObject clouds;
    private int spawntime = 5;

	// Use this for initialization
	void Start () {
        StartCoroutine(CloudTimer());
	}
	
	// Update is called once per frame
	void Update () {
   
    }
    IEnumerator CloudTimer() {
        while (true)
        {
            Instantiate(clouds, this.transform.position, this.transform.rotation);
            yield return new WaitForSeconds(12);
        }
}
}
