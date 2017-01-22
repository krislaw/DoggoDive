using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudSpawm : MonoBehaviour {

    public GameObject cloud1;
    public GameObject cloud2;
    public GameObject cloud3;

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
            float picker = Random.Range(-1f, 3f);
            if(picker < 0)
            {
                Instantiate(cloud3, this.transform.position, this.transform.rotation);
            }
            else if(picker < 2)
            {
                Instantiate(cloud1, this.transform.position, this.transform.rotation);
            }
            else
            {
                Instantiate(cloud2, this.transform.position, this.transform.rotation);
            }
            
            yield return new WaitForSeconds(3.5f);
        }
}
}
